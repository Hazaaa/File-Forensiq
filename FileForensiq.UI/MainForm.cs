using FileForensiq.Core;
using FileForensiq.Core.Models;
using FileForensiq.Core.Serializable;
using FileForensiq.Redis;
using FileForensiq.UI.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileForensiq.UI
{
    public partial class MainForm : Form
    {
        private readonly FileSystemManipulation filesManipulation;
        private readonly RedisFunctions redis;


        private bool sortDescending = true;
        public string CacheTime { get
            {
                return redis.GetValueForKey("CacheTime");
            }
            set {
                redis.AddNewConfig("CacheTime", value);
            } }

        public MainForm()
        {
            InitializeComponent();
            filesManipulation = new FileSystemManipulation();
            redis = new RedisFunctions();
        }

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetPartitionLettersCombobox();
            timer.Start();
            tvFileSystem.TreeViewNodeSorter = new TreeNodeSorter();
            bool serverStarted = redis.StartRedisServer();
            if (!serverStarted)
            {
                MessageBox.Show("You can still use application, but won't have cache feature. Try restarting application and check if Redis Server files are in application folder.", "Redis Server didn't started.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblRedisServerInfo.Text = "Redis Server is not running.";
                lblRedisServerInfo.ForeColor = Color.Red;
                btnStartRedis.Visible = true;
            }
            else
            {
                lblRedisServerInfo.Text = "Redis Server is running...";
                lblRedisServerInfo.ForeColor = Color.Green;
                cbxCacheEvery.SelectedItem = CacheTime;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            redis.ShutDownRedisServer();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            long memoryUsage = (Process.GetCurrentProcess().PrivateMemorySize64 / 1024) / 1024;
            lblMemoryMB.Text = String.Format("~ {0} MB", memoryUsage.ToString());

            try
            {
                var serverIsRunning = System.Diagnostics.Process.GetProcessById(redis.ServerStarted);
                lblRedisServerInfo.Text = "Redis Server is running...";
                lblRedisServerInfo.ForeColor = Color.Green;
                btnStartRedis.Visible = false;
            }
            catch (Exception)
            {
                lblRedisServerInfo.Text = "Redis Server is not running.";
                lblRedisServerInfo.ForeColor = Color.Red;
                btnStartRedis.Visible = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFileTreeView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxPartitionLetters_Click(object sender, EventArgs e)
        {
            SetPartitionLettersCombobox();
        }

        private void cbxSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tvFileSystem.Nodes.Count != 0)
            {
                ShowHideDetailLabels(false);
                if (dgvFiles.Rows.Count != 0)
                {
                    dgvFiles.Rows.Clear();
                }

                SortTreeView();
            }
        }

        private void lblSortArrow_Click(object sender, EventArgs e)
        {
            if (cbxSortBy.SelectedIndex != -1)
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
            try
            {
                filesManipulation.OpenFile(tvFileSystem.SelectedNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tvFileSystem_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedNode = tvFileSystem.SelectedNode;
            if (selectedNode == null)
            {
                return;
            }

            if (selectedNode is DirectoryTreeNode)
            {
                ShowDirectoryFileDetails(true, selectedNode);
            }
            else //Is file
            {
                ShowDirectoryFileDetails(false, selectedNode);
            }
        }

        private void btnStartRedis_Click(object sender, EventArgs e)
        {
            bool serverStarted = redis.StartRedisServer();
            if (!serverStarted)
            {
                MessageBox.Show("You can still use application, but won't have cache feature. Try restarting application and check if Redis Server files are in application folder.", "Redis Server didn't started.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbxCacheEvery_SelectedIndexChanged(object sender, EventArgs e)
        {
            CacheTime = cbxCacheEvery.SelectedItem.ToString();
        }

        private void bgwCache_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var args = e.Argument as PartitionProcessingResult;

            SerializableTreeView stw = new SerializableTreeView(args.NumberOfReturnedResults);
            stw.ConvertToSerializeData(args);

            // Settings has to be provided so polymorphism deserialization works.
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var serialized = JsonConvert.SerializeObject(stw, settings);
            var result = redis.AddNewCache(GenerateCacheKey(args.RootNode.Text.Substring(0, 3)), serialized);

            e.Result = result;
        }

        private void bgwCache_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Unable to cache data.", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if ((bool)e.Result)
            {
                lblLastCache.Visible = true;
                lblLastCacheLabel.Visible = true;
                lblLastCache.Text = DateTime.Now.ToString();
            }
        }

        #endregion

        #region Helpers

        public async void LoadFileTreeView()
        {
            btnSearch.Text = "Processing...";
            btnSearch.Enabled = false;
            pbxLoading.Visible = true;
            lblResultStats.Visible = false;
            tvFileSystem.Nodes.Clear();
            cbxSortBy.Enabled = false;
            lblSortArrow.Visible = false;
            ShowHideDetailLabels(false);
            if(dgvFiles.Rows.Count != 0)
            {
                dgvFiles.Rows.Clear();
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // With Task.Run UI is still responsive while data is being collected
            string selectedDrive = cbxPartitionLetters.SelectedItem?.ToString();
            PartitionProcessingResult files = null;

            if (CheckIfIsCached(selectedDrive))
            {
                files = await Task.Run(() => GetCachedData(selectedDrive));
            }
            else
            {
                files = await Task.Run(() => filesManipulation.GetPartitionFileTree(selectedDrive, true));
            }
            
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

                if (!CheckIfIsCached(selectedDrive))
                {
                    CacheData(files);
                }
            } 
            else
            {
                MessageBox.Show("Error occured while trying to get files.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pbxLoading.Visible = false;
            btnSearch.Text = "Process";
            btnSearch.Enabled = true;
        }

        public void CacheData(PartitionProcessingResult result)
        {
            bgwCache.RunWorkerAsync(argument: result);
        }

        public PartitionProcessingResult GetCachedData(string selectedDrive)
        {
            var key = GenerateCacheKey(selectedDrive);
            var serialized = redis.GetValueForKey(key);

            if (!String.IsNullOrEmpty(serialized))
            {
                try
                {
                    // Settings has to be provided so polymorphism deserialization works.
                    JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                    var deserialized = JsonConvert.DeserializeObject<SerializableTreeView>(serialized, settings);

                    return deserialized.ConvertToTreeViewData();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        public bool CheckIfIsCached(string selectedDrive)
        {
            return lblLastCache.Visible && !CheckIfCacheExpired() && redis.CheckIfKeyExists(GenerateCacheKey(selectedDrive));
        }

        public bool CheckIfCacheExpired()
        {
            var result = DateTime.Compare(DateTime.Now, DateTime.Parse(lblLastCache.Text).AddMinutes(CacheTime == "" ? 10 : int.Parse(CacheTime.Substring(0,1))));

            return result == 1 ? true : false;
        }

        public void SetPartitionLettersCombobox()
        {
            //Checking if new partition appeared (e.g. USB flash inserted) and updating combobox
            string lastSelectedDriver = cbxPartitionLetters.SelectedItem?.ToString();
            var drivesLetters = Directory.GetLogicalDrives();
            cbxPartitionLetters.Items.Clear();
            cbxPartitionLetters.Items.AddRange(drivesLetters.Select(x => x.ToString()).ToArray());

            if (!String.IsNullOrEmpty(lastSelectedDriver))
            {
                cbxPartitionLetters.SelectedItem = lastSelectedDriver;
            }
            else
            {
                cbxPartitionLetters.SelectedIndex = 0;
            }
        }

        public void SortTreeView()
        {
            switch (cbxSortBy.SelectedIndex)
            {
                // Sort by name
                case 0:
                    (tvFileSystem.TreeViewNodeSorter as TreeNodeSorter).SortByMethod = SortBy.Name;
                    (tvFileSystem.TreeViewNodeSorter as TreeNodeSorter).Descending = sortDescending;
                    tvFileSystem.Sort();
                    break;

                // Sort by size
                case 1:
                    (tvFileSystem.TreeViewNodeSorter as TreeNodeSorter).SortByMethod = SortBy.Size;
                    (tvFileSystem.TreeViewNodeSorter as TreeNodeSorter).Descending = sortDescending;
                    tvFileSystem.Sort();
                    break;

                // Sort by number of files
                case 2:
                    (tvFileSystem.TreeViewNodeSorter as TreeNodeSorter).SortByMethod = SortBy.NumberOfFiles;
                    (tvFileSystem.TreeViewNodeSorter as TreeNodeSorter).Descending = sortDescending;
                    tvFileSystem.Sort();
                    break;

                // Sort by time created
                case 3:
                    (tvFileSystem.TreeViewNodeSorter as TreeNodeSorter).SortByMethod = SortBy.TimeCreated;
                    (tvFileSystem.TreeViewNodeSorter as TreeNodeSorter).Descending = sortDescending;
                    tvFileSystem.Sort();
                    break;

                // Sort by last modify
                case 4:
                    (tvFileSystem.TreeViewNodeSorter as TreeNodeSorter).SortByMethod = SortBy.TimeLastModified;
                    (tvFileSystem.TreeViewNodeSorter as TreeNodeSorter).Descending = sortDescending;
                    tvFileSystem.Sort();
                    break;

                // Sort by last access
                case 5:
                    (tvFileSystem.TreeViewNodeSorter as TreeNodeSorter).SortByMethod = SortBy.TimeLastAccessed;
                    (tvFileSystem.TreeViewNodeSorter as TreeNodeSorter).Descending = sortDescending;
                    tvFileSystem.Sort();
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
                lblFolderFileLabel.Location = new System.Drawing.Point(57, 11);
                lblFolderFileName.Location = new System.Drawing.Point(106, 14);

                lblTypeLabel.Location = new System.Drawing.Point(57, 63);
                lblFolderFileType.Location = new System.Drawing.Point(107, 63);

                lblSizeLabel.Location = new System.Drawing.Point(59, 39);
                lblFolderFileSize.Location = new System.Drawing.Point(107, 39);
            }
        }

        public void ShowHideDetailLabels(bool show)
        {
            if(show)
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

        public void ShowDirectoryFileDetails(bool directory, TreeNode selectedNode)
        {
            dgvFiles.Rows.Clear();
            if (directory)
            {
                var dirInfo = selectedNode.Tag as DirectoryInfo;

                SetResetPositionOfDetailsLabels(true);

                lblFolderFileLabel.Text = "Folder:";
                lblFolderFileName.Text = dirInfo.Name;

                lblTypeLabel.Text = "Number of files:";
                lblFolderFileType.Text = (selectedNode as DirectoryTreeNode).NumberOfFiles.ToString();

                lblFolderFileSize.Text = DisplayFileSize((selectedNode as DirectoryTreeNode).Size);

                lblFolderFileCreated.Text = dirInfo.CreationTime.ToString();
                lblFileFolderLastAccess.Text = dirInfo.LastAccessTime.ToString();
                lblFolderFileLastModify.Text = dirInfo.LastWriteTime.ToString();

                //Show files in DataGridView
                foreach(var file in selectedNode.Nodes.Cast<TreeNode>().Where(x => !(x is DirectoryTreeNode)).Select(x => x.Tag as FileInfo))
                {
                    int row = dgvFiles.Rows.Count;
                    dgvFiles.Rows.Add();
                    dgvFiles.Rows[row].Cells[0].Value = file.Name;
                    dgvFiles.Rows[row].Cells[1].Value = file.Extension;
                    dgvFiles.Rows[row].Cells[2].Value = DisplayFileSize(file.Length);
                    dgvFiles.Rows[row].Cells[3].Value = file.CreationTime;
                    dgvFiles.Rows[row].Cells[4].Value = file.LastAccessTime;
                    dgvFiles.Rows[row].Cells[5].Value = file.LastWriteTime;
                }
            }
            else
            {
                var fileInfo = selectedNode.Tag as FileInfo;

                SetResetPositionOfDetailsLabels(false);

                lblFolderFileLabel.Text = "File:";
                lblFolderFileName.Text = fileInfo.Name;

                lblTypeLabel.Text = "Type:";
                lblFolderFileType.Text = fileInfo.Extension;
                lblFolderFileSize.Text = DisplayFileSize(fileInfo.Length);

                lblFolderFileCreated.Text = fileInfo.CreationTime.ToString();
                lblFileFolderLastAccess.Text = fileInfo.LastAccessTime.ToString();
                lblFolderFileLastModify.Text = fileInfo.LastWriteTime.ToString();
            }
        }

        public string GenerateCacheKey(string partitionLetter)
        {
            return partitionLetter + DateTime.Now.ToString("dd/MM/yyyy");
        }

        #endregion
    }
}
