using FileForensiq.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileForensiq.UI
{
    public partial class MainForm : Form
    {
        private readonly FilesManipulation filesManipulation;

        public MainForm()
        {
            InitializeComponent();
            filesManipulation = new FilesManipulation();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Setting Combobox with Drive letters
            var drivesLetters = Directory.GetLogicalDrives();
            cbxDriveLetters.Items.AddRange(drivesLetters.Select(x => x.ToString()).ToArray());
            cbxDriveLetters.SelectedIndex = 0;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Text = "Processing...";
            btnSearch.Enabled = false;
            pbxLoading.Visible = true;
            lblResultStats.Visible = false;
            tvFileSystem.BeginUpdate();
            tvFileSystem.Nodes.Clear();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // With Task.Run UI is still responsive while data is being collected
            string selectedDrive = cbxDriveLetters.SelectedItem?.ToString();
            var files = await Task.Run(() => filesManipulation.GetFilesTree(selectedDrive));

            stopWatch.Stop();

            // Showing results and configurating some controls
            if (files != null && files.RootNode != null)
            {
                lblResultStats.Text = String.Format("Time: {0}. Files Collected: {1}. Unauthorized Errors: {2}. Other Errors: {3}.", stopWatch.Elapsed, files.NumberOfFiles, files.UnauthorizedErrors, files.OtherErrors);
                lblResultStats.Visible = true;

                files.RootNode.ImageKey = "harddisk.png";
                files.RootNode.SelectedImageKey = "harddisk.png";

                tvFileSystem.Nodes.Add(files.RootNode);
                tvFileSystem.Nodes[0].Expand();
            }
            tvFileSystem.EndUpdate();

            pbxLoading.Visible = false;
            btnSearch.Text = "Process";
            btnSearch.Enabled = true;
        }

        private void cbxDriveLetters_Click(object sender, EventArgs e)
        {
            //Checking if new partition appeared (e.g. USB flash inserted) and updating combobox
            string lastSelectedDriver = cbxDriveLetters.SelectedItem?.ToString();
            var drivesLetters = Directory.GetLogicalDrives();
            cbxDriveLetters.Items.Clear();
            cbxDriveLetters.Items.AddRange(drivesLetters.Select(x => x.ToString()).ToArray());
            cbxDriveLetters.SelectedItem = lastSelectedDriver;
        }
    }
}
