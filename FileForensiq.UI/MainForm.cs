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
        public MainForm()
        {
            InitializeComponent();
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
            FilesManipulation filesManipulation = new FilesManipulation();

            btnSearch.Text = "Processing...";
            btnSearch.Enabled = false;
            pbxLoading.Visible = true;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // With Task.Run UI is still responsive while data is being collected
            string selectedDrive = cbxDriveLetters.SelectedItem?.ToString();
            var files = await Task.Run(() => filesManipulation.GetFilesNames(selectedDrive));

            stopWatch.Stop();

            // Showing results and configurating some controls
            lblResultStats.Text = String.Format("Time: {0}. Files Collected: {1}. Unauthorized Errors: {2}. Other Errors: {3}.", stopWatch.Elapsed, files.FilesNames.Count, files.UnauthorizedErrors, files.OtherErrors);
            lblResultStats.Visible = true;
            
            pbxLoading.Visible = false;
            
            btnSearch.Text = "Process";
            btnSearch.Enabled = true;
            //treeView1.Nodes.AddRange(files.FilesNames.Select(x => new TreeNode(x)).ToArray());
        }
    }
}
