using FileForensiq.Core;
using FileForensiq.Core.Models;
using FileForensiq.Database;
using FileForensiq.Database.Models;
using FileForensiq.UI.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private readonly DatabaseHelper database;
        private CacheModel forDisplayFile;

        private bool sortDescending = true;

        private ErrorForm ef;
        private FilterForm ff;
        private GraphicForm gf;

        public ErrorForm ErrorForm {
            get
            {
                if (ef == null || ef.IsDisposed)
                {
                    ef = new ErrorForm();
                    return ef;
                }
                else
                {
                    return ef;
                }
            } 
        }

        public FilterForm FilterForm
        {
            get
            {
                if (ff == null || ff.IsDisposed)
                {
                    ff = new FilterForm(cbxPartitionLetters.SelectedItem.ToString().Substring(0,1).ToLower());
                    return ff;
                }
                else
                {
                    return ff;
                }
            }
        }

        public GraphicForm GraphicForm
        {
            get
            {
                if (gf == null || gf.IsDisposed)
                {
                    gf = new GraphicForm(cbxPartitionLetters.SelectedItem.ToString().Substring(0, 1).ToLower(), forDisplayFile);
                    return gf;
                }
                else
                {
                    return gf;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            filesManipulation = new FileSystemManipulation();
            database = new DatabaseHelper();
        }

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetPartitionLettersCombobox();
            timer.Start();
            tvFileSystem.TreeViewNodeSorter = new TreeNodeSorter();
            CheckServerStatus();
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

        private void btnErrorLog_Click(object sender, EventArgs e)
        {
            ErrorForm.Show();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            FilterForm.Show();
        }

        private void btnShowStatistics_Click(object sender, EventArgs e)
        {
            var selectedNode = tvFileSystem.SelectedNode;
            if (selectedNode == null)
            {
                return;
            }

            if (selectedNode is DirectoryTreeNode)
            {
                var info = selectedNode.Tag as DirectoryInfo;

                forDisplayFile = new CacheModel()
                {
                    CreationTime = info.CreationTime,
                    Extension = "folder",
                    LastAccessTime = info.LastAccessTime,
                    LastModificationTime = info.LastWriteTime,
                    Name = info.FullName.Replace('\\', '/'),
                    NumberOfFiles = (selectedNode as DirectoryTreeNode).NumberOfFiles,
                    Size = (selectedNode as DirectoryTreeNode).Size
                };

                GraphicForm.Show();
            }
            else //Is file
            {
                var info = selectedNode.Tag as FileInfo;

                forDisplayFile = new CacheModel()
                {
                    CreationTime = info.CreationTime,
                    Extension = info.Extension.Split('.')[1],
                    LastAccessTime = info.LastAccessTime,
                    LastModificationTime = info.LastWriteTime,
                    Name = info.FullName.Replace('\\', '/'),
                    NumberOfFiles = 0,
                    Size = info.Length
                };

                GraphicForm.Show();
            }
        }

        private void btnShowDeletedFiles_Click(object sender, EventArgs e)
        {
            var selectedNode = tvFileSystem.SelectedNode;
            if (selectedNode == null)
            {
                return;
            }

            if (selectedNode is DirectoryTreeNode)
            {
                var info = selectedNode.Tag as DirectoryInfo;

                forDisplayFile = new CacheModel()
                {
                    CreationTime = info.CreationTime,
                    Extension = "folder",
                    LastAccessTime = info.LastAccessTime,
                    LastModificationTime = info.LastWriteTime,
                    Name = info.FullName.Replace('\\', '/'),
                    NumberOfFiles = (selectedNode as DirectoryTreeNode).NumberOfFiles,
                    Size = (selectedNode as DirectoryTreeNode).Size
                };

                FilterForm.RecievedFolder = forDisplayFile;
                FilterForm.Show();
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
                btnShowDeletedFiles.Visible = true;
                btnShowStatistics.Visible = true;
            }
            else //Is file
            {
                ShowDirectoryFileDetails(false, selectedNode);
                btnShowStatistics.Visible = true;
                btnShowDeletedFiles.Visible = false;
            }
        }

        private void tvFileSystem_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var expandNode = e.Node as DirectoryTreeNode;
            if (!expandNode.Expanded)
            {
                tvFileSystem.BeginUpdate();
                e.Node.Nodes.Clear();
                var children = filesManipulation.GetDirectoryChildren((expandNode.Tag as DirectoryInfo).FullName);

                if (children.Error == null && children.ChildNodes.Count != 0)
                {
                    e.Node.Nodes.AddRange(children.ChildNodes.ToArray());
                    expandNode.Expanded = true;
                }
                else if (children.Error != null)
                {
                    e.Node.ForeColor = Color.Red;
                    if (children.Error is UnauthorizedAccessException)
                    {
                        e.Node.Text += " (Unauthorized Access Error)";
                    }
                    else
                    {
                        e.Node.Text += " (Unknown Error Occured)";
                    }
                }
                tvFileSystem.EndUpdate();
            }
        }

        private void btnCheckServerStatus_Click(object sender, EventArgs e)
        {
            CheckServerStatus();
        }

        private void bgwCache_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var selectedDrive = e.Argument as string;

            string tableName = selectedDrive.Substring(0, 1).ToLower() + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year;

            bool tableCreated = database.CreateTable(tableName);

            if (tableCreated)
            {
                using (var dataTable = database.GenerateDataTableForBulkInsert())
                {
                    // Fills dataTable with data
                    var rootSize = filesManipulation.PrepareFileDetailsForCache(new DirectoryInfo(selectedDrive), dataTable);

                    // Chache data to db
                    database.InsertCacheData(tableName, dataTable);
                }

                e.Result = true;
            }
            else
            {
                e.Result = false;
            }
        }

        private void bgwCache_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Unable to cache data.", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if ((bool)e.Result)
                {
                    lblLastCache.Visible = true;
                    lblLastCacheLabel.Visible = true;
                    lblLastCache.Text = DateTime.Now.ToString();
                    SetConfigSetting("LastCache-" + cbxPartitionLetters.SelectedItem?.ToString().Substring(0,1), DateTime.Now.ToString("dd/MM/yyyy"));
                    btnSearch.Focus();
                } else
                {
                    lblLastCache.Visible = false;
                    btnSearch.Focus();
                }
            }
        }

        #endregion

        #region Helpers

        public async void LoadFileTreeView()
        {
            btnSearch.Text = "Processing...";
            btnSearch.Enabled = false;
            pbxLoading.Visible = true;
            tvFileSystem.Nodes.Clear();
            cbxSortBy.Enabled = false;
            lblSortArrow.Visible = false;
            ShowHideDetailLabels(false);
            if(dgvFiles.Rows.Count != 0)
            {
                dgvFiles.Rows.Clear();
            }
            
            string selectedDrive = cbxPartitionLetters.SelectedItem?.ToString();

            // Creating root node object and getting his child nodes
            DirectoryTreeNode rootNode = new DirectoryTreeNode(selectedDrive)
            {
                Tag = new DirectoryInfo(selectedDrive),
                ImageKey = "harddisk.png",
                SelectedImageKey = "harddisk.png"
            };
            var childs = await Task.Run(() => filesManipulation.GetDirectoryChildren(selectedDrive));

            // Showing results and configurating some controls
            if (childs.Error == null)
            {
                cbxSortBy.Enabled = true;
                lblSortArrow.Visible = true;

                tvFileSystem.BeginUpdate();

                rootNode.Nodes.AddRange(childs.ChildNodes.ToArray());
                tvFileSystem.Nodes.Add(rootNode);
                tvFileSystem.Nodes[0].Expand();

                tvFileSystem.EndUpdate();

                if (!CheckIfIsCached(selectedDrive))
                {
                    CacheData(selectedDrive);
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

        public void SetConfigSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Minimal);
        }

        public string GetConfigSetting(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            var result = config.AppSettings.Settings[key];
            return result == null ? "" : result.Value;
        }

        public void CacheData(string selectedDrive)
        {
            lblLastCache.Visible = true;
            lblLastCache.Text = "Caching in progress...";
            bgwCache.RunWorkerAsync(argument: selectedDrive);
        }

        public bool CheckIfIsCached(string selectedDrive)
        {
            return GetConfigSetting("LastCache-" + selectedDrive.Substring(0,1)) != "" && GetConfigSetting("LastCache-" + selectedDrive.Substring(0, 1)) == DateTime.Now.ToString("dd/MM/yyyy");
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

        public async void ShowDirectoryFileDetails(bool directory, TreeNode selectedNode)
        {
            dgvFiles.Rows.Clear();
            if (directory)
            {
                var dirInfo = selectedNode.Tag as DirectoryInfo;
                var directoryNode = selectedNode as DirectoryTreeNode;

                SetResetPositionOfDetailsLabels(true);

                lblFolderFileLabel.Text = "Folder:";
                lblFolderFileName.Text = dirInfo.Name;

                lblTypeLabel.Text = "Number of files:";
                lblFolderFileType.Text = "...";

                lblFolderFileSize.Text = "...";

                lblFolderFileCreated.Text = dirInfo.CreationTime.ToString();
                lblFileFolderLastAccess.Text = dirInfo.LastAccessTime.ToString();
                lblFolderFileLastModify.Text = dirInfo.LastWriteTime.ToString();

                try
                {
                    //Show files in DataGridView
                    foreach (var file in dirInfo.EnumerateFiles())
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

                    if(!directoryNode.NumberOfFilesCalculated)
                    {
                        directoryNode.NumberOfFiles = await Task.Run(() => filesManipulation.CalculateNumberOfFiles(dirInfo));
                        directoryNode.NumberOfFilesCalculated = true;
                    }
                    lblFolderFileType.Text = directoryNode.NumberOfFiles.ToString();

                    if(!directoryNode.SizeCalculated)
                    {
                        directoryNode.Size = await Task.Run(() => filesManipulation.CalculateDirectorySize(dirInfo));
                        directoryNode.SizeCalculated = true;
                    }
                    lblFolderFileSize.Text = DisplayFileSize(directoryNode.Size);
                }
                catch (Exception)
                {
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

        public async void CheckServerStatus()
        {
            lblServerStatus.Visible = true;
            lblServerStatus.Text = "Trying to connect...";

            if (await Task.Run(() => database.CheckIfServerIsRunning()))
            {
                lblServerStatus.Text = "SQL Server is running...";
                lblServerStatus.ForeColor = Color.Green;
            }
            else
            {
                lblServerStatus.Text = "SQL Server in not running.";
                lblServerStatus.ForeColor = Color.Red;

                MessageBox.Show("SQL Server is not running.\nYou can still use application but without functionality of Caching and information about files from past.\nYou can start SQL Server without restarting this application.", "Information:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion
    }
}
