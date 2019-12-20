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
        private bool sortDescending = false;

        public MainForm()
        {
            InitializeComponent();
            filesManipulation = new FileSystemManipulation();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FormHelper.SetPartitionLettersCombobox(cbxPartitionLetters);
            timer.Start();
            tvFileSystem.TreeViewNodeSorter = new TreeNodeSorter();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            long memoryUsage = (Process.GetCurrentProcess().PrivateMemorySize64 / 1024) / 1024;
            lblMemoryMB.Text = String.Format("~ {0} MB", memoryUsage.ToString());
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Text = "Processing...";
            btnSearch.Enabled = false;
            pbxLoading.Visible = true;
            lblResultStats.Visible = false;
            tvFileSystem.Nodes.Clear();
            cbxSortBy.Enabled = false;
            lblSortArrow.Visible = false;

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
                cbxSortBy.Enabled = true;
                lblSortArrow.Visible = true;

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

        private void cbxSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tvFileSystem.Nodes.Count != 0)
            {
                FormHelper.SortTreeView(cbxSortBy, tvFileSystem, sortDescending);
            }
        }

        private void lblSortArrow_Click(object sender, EventArgs e)
        {
            if(cbxSortBy.SelectedIndex != -1)
            {
                if (lblSortArrow.Text == "↓")
                {
                    sortDescending = true;
                    lblSortArrow.Text = "↑";
                }
                else
                {
                    sortDescending = false;
                    lblSortArrow.Text = "↓";
                }
            }
        }

        private void tvFileSystem_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            filesManipulation.OpenFile(tvFileSystem.SelectedNode);
        }
    }
}
