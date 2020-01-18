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

        public enum FilterOptions
        {
            ShowAll,
            TimeCreated,
            LastModifyTime,
            LastAccessTime
        }

        public enum FilterPeriod
        {
            ForDay,
            ForPeriod,
            For30Days
        }

        public FilterForm()
        {
            InitializeComponent();
        }

        public FilterForm(string drive) : base()
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

        #endregion

        #region Helpers

        public void PopulateDataGridView()
        {
            if (cbxFilterOptions.SelectedIndex == -1)
                return;

            FilterOptions selectedOption = (FilterOptions) cbxFilterOptions.SelectedIndex;
            FilterPeriod selectedPeriod = (FilterPeriod) cbxFilterPeriod.SelectedIndex;

            DateTime selectedDateFrom = dtpPeriodFrom.Value;
            DateTime selectedDateTo = dtpPeriodTo.Value;

            List<string> selectedTypes = clbFileTypes.CheckedItems.Cast<string>().ToList();

            switch (selectedOption)
            {
                case FilterOptions.ShowAll:
                    dgvFiles.DataSource = database.GetAllFiles(selectedDrive, selectedTypes);
                    SetUpDataGridViewColumnsSettings();
                    lblNumberOfFiles.Visible = true;
                    lblNumberOfFiles.Text = dgvFiles.Rows.Count.ToString();
                    break;

                case FilterOptions.TimeCreated:
                    // TODO
                    SetUpDataGridViewColumnsSettings();
                    lblNumberOfFiles.Visible = true;
                    lblNumberOfFiles.Text = dgvFiles.Rows.Count.ToString();
                    break;

                case FilterOptions.LastModifyTime:
                    // TODO
                    SetUpDataGridViewColumnsSettings();
                    lblNumberOfFiles.Visible = true;
                    lblNumberOfFiles.Text = dgvFiles.Rows.Count.ToString();
                    break;

                case FilterOptions.LastAccessTime:
                    // TODO
                    SetUpDataGridViewColumnsSettings();
                    lblNumberOfFiles.Visible = true;
                    lblNumberOfFiles.Text = dgvFiles.Rows.Count.ToString();
                    break;

                default:
                    break;
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
            List<string> types = database.GetFileTypes(selectedDrive.Substring(0, 1).ToLower());

            if(types != null)
            {
                clbFileTypes.Items.AddRange(types.ToArray());
            }
        }

        public void SetUpDateTimePickers()
        {
            dtpPeriodFrom.MinDate = DateTime.Now.AddDays(-30);
            dtpPeriodFrom.MaxDate = DateTime.Now;
            dtpPeriodTo.MinDate = DateTime.Now.AddDays(-30);
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

                case 2: // Fpr 30 days
                    gbxTimePeriod.Enabled = true;
                    dtpPeriodTo.Enabled = false;
                    dtpPeriodTo.Value = dtpPeriodTo.MaxDate;
                    dtpPeriodFrom.Enabled = false;
                    dtpPeriodFrom.Value = dtpPeriodFrom.MinDate;
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
