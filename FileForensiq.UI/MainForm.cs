using FileForensiq.Core;
using FileForensiq.UI.Helpers;
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
        private readonly FileSystemManipulation filesManipulation;

        public MainForm()
        {
            InitializeComponent();
            filesManipulation = new FileSystemManipulation();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FormHelper.SetPartitionLettersCombobox(cbxPartitionLetters);
            timer.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Start();
            timer.Dispose();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Text = "Processing...";
            btnSearch.Enabled = false;
            pbxLoading.Visible = true;
            lblResultStats.Visible = false;
            tvFileSystem.Nodes.Clear();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // With Task.Run UI is still responsive while data is being collected
            string selectedDrive = cbxPartitionLetters.SelectedItem?.ToString();
            var files = await Task.Run(() => filesManipulation.GetPartitionFileTree(selectedDrive, true));

            stopWatch.Stop();

            // Showing results and configurating some controls
            if (files != null && files.RootNode != null)
            {
                lblResultStats.Text = String.Format("Time: {0}. Files Collected: {1}. Unauthorized Errors: {2}. Other Errors: {3}.", stopWatch.Elapsed, files.NumberOfReturnedResults, files.UnauthorizedErrors, files.OtherErrors);
                lblResultStats.Visible = true;

                files.RootNode.ImageKey = "harddisk.png";
                files.RootNode.SelectedImageKey = "harddisk.png";

                tvFileSystem.Nodes.Add(files.RootNode);
                tvFileSystem.Nodes[0].Expand();
            }

            pbxLoading.Visible = false;
            btnSearch.Text = "Process";
            btnSearch.Enabled = true;
        }

        private void cbxPartitionLetters_Click(object sender, EventArgs e)
        {
            FormHelper.SetPartitionLettersCombobox(cbxPartitionLetters);
        }

        private async void cbxSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tvFileSystem.Nodes.Count != 0)
            {
                switch (cbxSortBy.SelectedIndex)
                {
                    // Sort by name
                    case 0:
                        await Task.Run(() => tvFileSystem.Invoke((MethodInvoker)(() => tvFileSystem.Sort())));
                        break;

                    // Sort by size
                    case 1:
                        break;

                    // Sorty by number of files
                    case 2:
                        break;

                    default:
                        break;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            long memoryUsage = (Process.GetCurrentProcess().PrivateMemorySize64/1024)/1024;
            lblMemoryMB.Text = String.Format("~ {0} MB", memoryUsage.ToString());
        }
    }
}
