using FileForensiq.Database;
using FileForensiq.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileForensiq.UI
{
    public partial class FilterForm : Form
    {
        private string selectedDrive;
        private DatabaseHelper database;
        private List<CacheModel> retrievedData;

        public CacheModel RecievedFolder { get; set; }

        public enum FilterOptions
        {
            ShowAll,
            TimeCreated,
            LastModifyTime,
            LastAccessTime,
            DeletedFiles
        }

        public enum FilterPeriod
        {
            ForDay,
            ForPeriod,
            For30Days
        }

        private GraphicForm gf;

        public GraphicForm GraphicForm
        {
            get
            {
                if (gf == null || gf.IsDisposed)
                {
                    gf = new GraphicForm(selectedDrive, (CacheModel)dgvFiles.SelectedRows[0].DataBoundItem);
                    return gf;
                }
                else
                {
                    return gf;
                }
            }
        }

        private ChartForm cf;

        public ChartForm ChartForm
        {
            get
            {
                if (cf == null || cf.IsDisposed)
                {
                    cf = new ChartForm((List<CacheModel>)dgvFiles.DataSource);
                    return cf;
                }
                else
                {
                    return cf;
                }
            }
        }

        public FilterForm()
        {
            InitializeComponent();
        }

        public FilterForm(string drive)
        {
            InitializeComponent();
            selectedDrive = drive;
            this.Text = drive + " Filter";
            database = new DatabaseHelper();
        }

        #region Events

        private void FilterForm_Load(object sender, EventArgs e)
        {
            PopulateFileTypeCombobox();
            SetUpDateTimePickers();
            gbxTimePeriod.Enabled = false;

            if(RecievedFolder != null)
            {
                cbxFilterOptions.SelectedIndex = (int)FilterOptions.DeletedFiles;
            }
        }

        private void cbxFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComboboxesForFilterOptions();
        }

        private void cbxFilterPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComboboxesForFilterOptions();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblNumberOfFiles.Visible = false;
            lblErrorLabel.Visible = false;
            PopulateDataGridView();
        }

        private int _previousIndex;
        private bool _sortDirection;
        private void dgvFiles_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == _previousIndex)
                _sortDirection ^= true; // toggle direction

            dgvFiles.DataSource = SortData(
                (List<CacheModel>)dgvFiles.DataSource, dgvFiles.Columns[e.ColumnIndex].Name, _sortDirection);

            _previousIndex = e.ColumnIndex;
        }

        private void dgvFiles_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GraphicForm.Show();
        }

        private void btnShowStatistics_Click(object sender, EventArgs e)
        {
            ChartForm.Show();
        }

        private void tbxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (retrievedData == null || retrievedData.Count == 0)
                return;

            dgvFiles.DataSource = retrievedData.Where(x => x.Name.Contains(tbxSearch.Text)).ToList();
            dgvFiles.Update();
            dgvFiles.Refresh();
            lblNumberOfFiles.Text = dgvFiles.Rows.Count.ToString();
        }

        #endregion

        #region Helpers

        public void PopulateDataGridView()
        {
            if (cbxFilterOptions.SelectedIndex == -1)
                return;

            FilterOptions selectedOption = (FilterOptions) cbxFilterOptions.SelectedIndex;
            FilterPeriod selectedPeriod = (FilterPeriod) cbxFilterPeriod.SelectedIndex;

            DateTime selectedDateFrom = dtpPeriodFrom.Value.Date;
            DateTime selectedDateTo = dtpPeriodTo.Value.Date;

            List<string> selectedTypes = clbFileTypes.CheckedItems.Cast<string>().ToList();

            switch (selectedOption)
            {
                case FilterOptions.ShowAll:
                    ShowAllFiles(selectedTypes);
                    break;

                case FilterOptions.TimeCreated:
                    ShowFilesByPeriodOfTime("CreationTime", selectedPeriod, selectedDateFrom, selectedDateTo, selectedTypes);
                    break;

                case FilterOptions.LastModifyTime:
                    ShowFilesByPeriodOfTime("LastModificationTime", selectedPeriod, selectedDateFrom, selectedDateTo, selectedTypes);
                    break;

                case FilterOptions.LastAccessTime:
                    ShowFilesByPeriodOfTime("LastAccessTime", selectedPeriod, selectedDateFrom, selectedDateTo, selectedTypes);
                    break;

                case FilterOptions.DeletedFiles:
                    ShowDeletedFiles(selectedPeriod, selectedDateFrom, selectedDateTo, selectedTypes);
                    break;
                default:
                    break;
            }
        }

        public void ShowAllFiles(List<string> selectedTypes)
        {
            try
            {
                retrievedData = database.GetAllFiles(selectedDrive, selectedTypes).Distinct(new CacheModelComaparer()).ToList();
                dgvFiles.DataSource = retrievedData;
                SetUpDataGridViewColumnsSettings();
                lblNumberOfFiles.Visible = true;
                lblNumberOfFiles.Text = dgvFiles.Rows.Count.ToString();
            }
            catch (Exception)
            {
                lblErrorLabel.Visible = true;
            }
        }

        public void ShowFilesByPeriodOfTime(string columnName, FilterPeriod selectedPeriod, DateTime selectedDateFrom, DateTime selectedDateTo, List<string> selectedTypes)
        {
            try
            {
                switch (selectedPeriod)
                {
                    case FilterPeriod.ForDay:
                        dgvFiles.DataSource = database.GetFilesByPeriodOfTime(selectedDrive, columnName, selectedTypes, selectedDateFrom).Distinct(new CacheModelComaparer()).ToList();
                        break;
                    default:
                        dgvFiles.DataSource = database.GetFilesByPeriodOfTime(selectedDrive, columnName, selectedTypes, selectedDateFrom, selectedDateTo).Distinct(new CacheModelComaparer()).ToList();
                        break;
                }

                SetUpDataGridViewColumnsSettings();
                lblNumberOfFiles.Visible = true;
                lblNumberOfFiles.Text = dgvFiles.Rows.Count.ToString();
            }
            catch (Exception)
            {
                lblErrorLabel.Visible = true;
            }
        }

        public void ShowDeletedFiles(FilterPeriod selectedPeriod, DateTime selectedDateFrom, DateTime selectedDateTo, List<string> selectedTypes) 
        {
            try
            {
                switch (selectedPeriod)
                {
                    case FilterPeriod.ForDay:
                        if(RecievedFolder == null)
                        {
                            dgvFiles.DataSource = database.GetDeletedFilesForFolder(selectedDrive, null, selectedTypes, selectedDateFrom);
                        }
                        else
                        {
                            dgvFiles.DataSource = database.GetDeletedFilesForFolder(selectedDrive, RecievedFolder.Name, selectedTypes, selectedDateFrom);
                        }
                        break;
                    default:
                        if(RecievedFolder == null)
                        {
                            dgvFiles.DataSource = database.GetDeletedFilesForFolder(selectedDrive, null, selectedTypes, selectedDateFrom, selectedDateTo);
                        }
                        else
                        {
                            dgvFiles.DataSource = database.GetDeletedFilesForFolder(selectedDrive, RecievedFolder.Name, selectedTypes, selectedDateFrom, selectedDateTo);
                        }
                        break;
                }

                SetUpDataGridViewColumnsSettings();
                lblNumberOfFiles.Visible = true;
                lblNumberOfFiles.Text = dgvFiles.Rows.Count.ToString();
            }
            catch (Exception)
            {
                lblErrorLabel.Visible = true;
            }
        }

        public void SetUpDataGridViewColumnsSettings()
        {
            foreach (var column in dgvFiles.Columns.Cast<DataGridViewColumn>().ToList())
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        public List<CacheModel> SortData(List<CacheModel> list, string column, bool ascending)
        {
            return ascending ?
                list.OrderBy(_ => _.GetType().GetProperty(column).GetValue(_)).ToList() :
                list.OrderByDescending(_ => _.GetType().GetProperty(column).GetValue(_)).ToList();
        }

        public void PopulateFileTypeCombobox()
        {
            try
            {
                List<string> types = database.GetFileTypes(selectedDrive.Substring(0, 1).ToLower());

                if (types != null)
                {
                    clbFileTypes.Items.AddRange(types.ToArray());
                }
            }
            catch (Exception)
            {
                lblErrorLabel.Visible = true;
            }
        }

        public void SetUpDateTimePickers()
        {
            dtpPeriodFrom.MinDate = DateTime.Now.AddYears(-10);
            dtpPeriodFrom.Value = DateTime.Now;
            dtpPeriodFrom.MaxDate = DateTime.Now;
            dtpPeriodTo.MinDate = DateTime.Now.AddYears(-10);
            dtpPeriodTo.Value = DateTime.Now;
            dtpPeriodTo.MaxDate = DateTime.Now;
        }

        public void SetComboboxesForFilterOptions()
        {
            switch (cbxFilterPeriod.SelectedIndex)
            {
                case -1:
                    gbxTimePeriod.Enabled = false;
                    dtpPeriodTo.Enabled = true;
                    dtpPeriodFrom.Enabled = true;
                    break;

                case 0: // For day
                    gbxTimePeriod.Enabled = true;
                    dtpPeriodTo.Enabled = false;
                    dtpPeriodFrom.Enabled = true;
                    break;

                case 1: // For period
                    gbxTimePeriod.Enabled = true;
                    dtpPeriodTo.Enabled = true;
                    dtpPeriodFrom.Enabled = true;
                    break;

                case 2: // For 30 days
                    gbxTimePeriod.Enabled = true;
                    dtpPeriodTo.Enabled = false;
                    dtpPeriodTo.Value = dtpPeriodTo.MaxDate;
                    dtpPeriodFrom.Enabled = false;
                    dtpPeriodFrom.Value = dtpPeriodTo.MaxDate.AddDays(-30);
                    break;

                default:
                    break;
            }
        }

        public string DisplayFileSize(long size)
        {
            // Displaying size of files in KB, MB, GB or TB
            var tmp = ((size) / 1024f) / 1024f;
            if (tmp < 1.0)
            {
                return (size) / 1024f + " KB";
            }
            else if (tmp > 1000)
            {
                return (tmp / 1000f) + " GB";
            }
            else if (tmp > 1000000)
            {
                return (tmp / 953674f) + " TB";
            }
            else
            {
                return tmp + " MB";
            }
        }

        #endregion
    }
}
