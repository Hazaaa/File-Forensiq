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
    public partial class GraphicForm : Form
    {
        private CacheModel selectedFile;
        private List<CacheModel> perviousFileData;
        private string selectedDrive;
        private DatabaseHelper database;

        public enum GraphicOptions
        {
            Size,
            NumberOfFiles,
            TimeAccess,
            TimeModify
        }

        public GraphicForm()
        {
            InitializeComponent();
        }

        public GraphicForm(string drive, CacheModel file)
        {
            InitializeComponent();
            database = new DatabaseHelper();
            selectedFile = file;
            selectedDrive = drive;
        }

        #region Events

        private void GraphicForm_Load(object sender, EventArgs e)
        {
            ShowDirectoryFileDetails();
            perviousFileData = database.GetFileColumnHistory(selectedDrive, selectedFile.Name);
            cbxGraphicOptions.SelectedIndex = 0;
        }

        private void cbxGraphicOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch ((GraphicOptions)cbxGraphicOptions.SelectedIndex)
                {
                    case GraphicOptions.Size:
                        ClearChart();
                        chart.Titles.Add("Size over 30 days of period (In MB):");
                        var series = chart.Series.Add("Size");
                        series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        foreach (CacheModel data in perviousFileData)
                        {
                            series.Points.AddXY(data.DateCached.Split('_').ToList().Skip(1).ToList().Aggregate((x,y) => x + "-" + y), (data.Size / 1024f) / 1024f);
                        }
                        break;

                    case GraphicOptions.NumberOfFiles:
                        break;

                    case GraphicOptions.TimeAccess:
                        break;

                    case GraphicOptions.TimeModify:
                        break;

                    default:
                        break;
                }
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region Helpers

        public void ClearChart()
        {
            chart.Series.Clear();
            chart.Titles.Clear();
            foreach (var series in chart.Series)
            {
                series.Points.Clear();
            }
        }

        public void ShowDirectoryFileDetails()
        {
            if (selectedFile.Extension == "folder")
            {
                SetResetPositionOfDetailsLabels(true);

                lblFolderFileLabel.Text = "Folder:";
                lblFolderFileName.Text = selectedFile.Name.Split('/').Last();

                lblTypeLabel.Text = "Number of files:";
                lblFolderFileType.Text = selectedFile.NumberOfFiles.ToString();

                lblFolderFileSize.Text = DisplayFileSize(selectedFile.Size);

                lblFolderFileCreated.Text = selectedFile.CreationTime.ToString();
                lblFileFolderLastAccess.Text = selectedFile.LastAccessTime.ToString();
                lblFolderFileLastModify.Text = selectedFile.LastModificationTime.ToString();
            }
            else
            {
                SetResetPositionOfDetailsLabels(false);

                lblFolderFileLabel.Text = "File:";
                lblFolderFileName.Text = selectedFile.Name.Split('/').Last();

                lblTypeLabel.Text = "Type:";
                lblFolderFileType.Text = selectedFile.Extension;
                lblFolderFileSize.Text = DisplayFileSize(selectedFile.Size);

                lblFolderFileCreated.Text = selectedFile.CreationTime.ToString();
                lblFileFolderLastAccess.Text = selectedFile.LastAccessTime.ToString();
                lblFolderFileLastModify.Text = selectedFile.LastModificationTime.ToString();
            }
        }

        public void SetResetPositionOfDetailsLabels(bool directory)
        {
            ShowHideDetailLabels(true);

            if (directory)
            {
                lblFolderFileName.Location = new System.Drawing.Point(116, 14);
                lblFolderFileLabel.Location = new System.Drawing.Point(46, 11);

                lblTypeLabel.Location = new System.Drawing.Point(1, 63);
                lblFolderFileType.Location = new System.Drawing.Point(117, 63);

                lblFolderFileSize.Location = new System.Drawing.Point(117, 39);
                lblSizeLabel.Location = new System.Drawing.Point(70, 39);
            }
            else
            {
                lblFolderFileLabel.Location = new System.Drawing.Point(13, 11);
                lblFolderFileName.Location = new System.Drawing.Point(62, 13);

                lblTypeLabel.Location = new System.Drawing.Point(13, 63);
                lblFolderFileType.Location = new System.Drawing.Point(62, 63);

                lblSizeLabel.Location = new System.Drawing.Point(13, 39);
                lblFolderFileSize.Location = new System.Drawing.Point(62, 39);
            }
        }

        public void ShowHideDetailLabels(bool show)
        {
            if (show)
            {
                lblFolderFileName.Visible = true;
                lblFolderFileType.Visible = true;
                lblFolderFileSize.Visible = true;
                lblFolderFileCreated.Visible = true;
                lblFileFolderLastAccess.Visible = true;
                lblFolderFileLastModify.Visible = true;
            }
            else
            {
                lblFolderFileName.Visible = false;
                lblFolderFileType.Visible = false;
                lblFolderFileSize.Visible = false;
                lblFolderFileCreated.Visible = false;
                lblFileFolderLastAccess.Visible = false;
                lblFolderFileLastModify.Visible = false;
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
