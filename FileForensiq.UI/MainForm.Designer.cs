﻿namespace FileForensiq.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnSearch = new System.Windows.Forms.Button();
            this.tvFileSystem = new System.Windows.Forms.TreeView();
            this.imglFilesIcons = new System.Windows.Forms.ImageList(this.components);
            this.cbxPartitionLetters = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.cbxSortBy = new System.Windows.Forms.ComboBox();
            this.lblMemoryUsage = new System.Windows.Forms.Label();
            this.lblMemoryMB = new System.Windows.Forms.Label();
            this.lblSortArrow = new System.Windows.Forms.Label();
            this.pbxLoading = new System.Windows.Forms.PictureBox();
            this.btnErrorLog = new System.Windows.Forms.Button();
            this.pnlFolderDetails = new System.Windows.Forms.Panel();
            this.lblFolderFileType = new System.Windows.Forms.Label();
            this.lblTypeLabel = new System.Windows.Forms.Label();
            this.lblFolderFileLastModify = new System.Windows.Forms.Label();
            this.lblLastModifyLabel = new System.Windows.Forms.Label();
            this.lblFileFolderLastAccess = new System.Windows.Forms.Label();
            this.lblLastAccessLabel = new System.Windows.Forms.Label();
            this.lblFolderFileCreated = new System.Windows.Forms.Label();
            this.lblCreatedLabel = new System.Windows.Forms.Label();
            this.lblFolderFileSize = new System.Windows.Forms.Label();
            this.lblSizeLabel = new System.Windows.Forms.Label();
            this.lblFolderFileName = new System.Windows.Forms.Label();
            this.lblFolderFileLabel = new System.Windows.Forms.Label();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastAccess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastModify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLastCache = new System.Windows.Forms.Label();
            this.lblLastCacheLabel = new System.Windows.Forms.Label();
            this.bgwCache = new System.ComponentModel.BackgroundWorker();
            this.cbxCacheEvery = new System.Windows.Forms.ComboBox();
            this.lblCacheEveryLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoading)).BeginInit();
            this.pnlFolderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(111, 14);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 28);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Process";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tvFileSystem
            // 
            this.tvFileSystem.ImageIndex = 0;
            this.tvFileSystem.ImageList = this.imglFilesIcons;
            this.tvFileSystem.Location = new System.Drawing.Point(16, 114);
            this.tvFileSystem.Margin = new System.Windows.Forms.Padding(4);
            this.tvFileSystem.Name = "tvFileSystem";
            this.tvFileSystem.SelectedImageIndex = 0;
            this.tvFileSystem.Size = new System.Drawing.Size(557, 409);
            this.tvFileSystem.TabIndex = 2;
            this.tvFileSystem.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvFileSystem_BeforeExpand);
            this.tvFileSystem.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFileSystem_AfterSelect);
            this.tvFileSystem.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFileSystem_NodeMouseDoubleClick);
            // 
            // imglFilesIcons
            // 
            this.imglFilesIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglFilesIcons.ImageStream")));
            this.imglFilesIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imglFilesIcons.Images.SetKeyName(0, "file.png");
            this.imglFilesIcons.Images.SetKeyName(1, "folder.png");
            this.imglFilesIcons.Images.SetKeyName(2, "harddisk.png");
            this.imglFilesIcons.Images.SetKeyName(3, "ai.png");
            this.imglFilesIcons.Images.SetKeyName(4, "avi.png");
            this.imglFilesIcons.Images.SetKeyName(5, "css.png");
            this.imglFilesIcons.Images.SetKeyName(6, "csv.png");
            this.imglFilesIcons.Images.SetKeyName(7, "dbf.png");
            this.imglFilesIcons.Images.SetKeyName(8, "docx.png");
            this.imglFilesIcons.Images.SetKeyName(9, "dwg.png");
            this.imglFilesIcons.Images.SetKeyName(10, "exe.png");
            this.imglFilesIcons.Images.SetKeyName(11, "fla.png");
            this.imglFilesIcons.Images.SetKeyName(12, "html.png");
            this.imglFilesIcons.Images.SetKeyName(13, "iso.png");
            this.imglFilesIcons.Images.SetKeyName(14, "js.png");
            this.imglFilesIcons.Images.SetKeyName(15, "jpg.png");
            this.imglFilesIcons.Images.SetKeyName(16, "json.png");
            this.imglFilesIcons.Images.SetKeyName(17, "mp3.png");
            this.imglFilesIcons.Images.SetKeyName(18, "mp4.png");
            this.imglFilesIcons.Images.SetKeyName(19, "pdf.png");
            this.imglFilesIcons.Images.SetKeyName(20, "png.png");
            this.imglFilesIcons.Images.SetKeyName(21, "pptx.png");
            this.imglFilesIcons.Images.SetKeyName(22, "psd.png");
            this.imglFilesIcons.Images.SetKeyName(23, "rtf.png");
            this.imglFilesIcons.Images.SetKeyName(24, "svg.png");
            this.imglFilesIcons.Images.SetKeyName(25, "txt.png");
            this.imglFilesIcons.Images.SetKeyName(26, "xlsx.png");
            this.imglFilesIcons.Images.SetKeyName(27, "xml.png");
            this.imglFilesIcons.Images.SetKeyName(28, "zip.png");
            this.imglFilesIcons.Images.SetKeyName(29, "cpp.png");
            this.imglFilesIcons.Images.SetKeyName(30, "as.png");
            this.imglFilesIcons.Images.SetKeyName(31, "dtd.png");
            this.imglFilesIcons.Images.SetKeyName(32, "tsx.png");
            this.imglFilesIcons.Images.SetKeyName(33, "ts.png");
            this.imglFilesIcons.Images.SetKeyName(34, "sql.png");
            this.imglFilesIcons.Images.SetKeyName(35, "php.png");
            this.imglFilesIcons.Images.SetKeyName(36, "sass.png");
            this.imglFilesIcons.Images.SetKeyName(37, "jsx.png");
            this.imglFilesIcons.Images.SetKeyName(38, "jsp.png");
            this.imglFilesIcons.Images.SetKeyName(39, "delphi.png");
            this.imglFilesIcons.Images.SetKeyName(40, "mkv.png");
            this.imglFilesIcons.Images.SetKeyName(41, "log.png");
            this.imglFilesIcons.Images.SetKeyName(42, "settings.png");
            // 
            // cbxPartitionLetters
            // 
            this.cbxPartitionLetters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPartitionLetters.FormattingEnabled = true;
            this.cbxPartitionLetters.Location = new System.Drawing.Point(16, 15);
            this.cbxPartitionLetters.Margin = new System.Windows.Forms.Padding(4);
            this.cbxPartitionLetters.Name = "cbxPartitionLetters";
            this.cbxPartitionLetters.Size = new System.Drawing.Size(85, 24);
            this.cbxPartitionLetters.TabIndex = 3;
            this.cbxPartitionLetters.Click += new System.EventHandler(this.cbxPartitionLetters_Click);
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(13, 86);
            this.lblSort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(57, 17);
            this.lblSort.TabIndex = 5;
            this.lblSort.Text = "Sort by:";
            // 
            // cbxSortBy
            // 
            this.cbxSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSortBy.Enabled = false;
            this.cbxSortBy.FormattingEnabled = true;
            this.cbxSortBy.Items.AddRange(new object[] {
            "Name",
            "Size",
            "Number of Files",
            "Time Created",
            "Last Write",
            "Last Access"});
            this.cbxSortBy.Location = new System.Drawing.Point(79, 81);
            this.cbxSortBy.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSortBy.Name = "cbxSortBy";
            this.cbxSortBy.Size = new System.Drawing.Size(132, 24);
            this.cbxSortBy.TabIndex = 6;
            this.cbxSortBy.SelectedIndexChanged += new System.EventHandler(this.cbxSortBy_SelectedIndexChanged);
            // 
            // lblMemoryUsage
            // 
            this.lblMemoryUsage.AutoSize = true;
            this.lblMemoryUsage.Location = new System.Drawing.Point(333, 539);
            this.lblMemoryUsage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemoryUsage.Name = "lblMemoryUsage";
            this.lblMemoryUsage.Size = new System.Drawing.Size(105, 17);
            this.lblMemoryUsage.TabIndex = 7;
            this.lblMemoryUsage.Text = "Memory usage:";
            // 
            // lblMemoryMB
            // 
            this.lblMemoryMB.AutoSize = true;
            this.lblMemoryMB.Location = new System.Drawing.Point(437, 540);
            this.lblMemoryMB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemoryMB.Name = "lblMemoryMB";
            this.lblMemoryMB.Size = new System.Drawing.Size(97, 17);
            this.lblMemoryMB.TabIndex = 8;
            this.lblMemoryMB.Text = "Memory in MB";
            // 
            // lblSortArrow
            // 
            this.lblSortArrow.AutoSize = true;
            this.lblSortArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSortArrow.Location = new System.Drawing.Point(217, 81);
            this.lblSortArrow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSortArrow.Name = "lblSortArrow";
            this.lblSortArrow.Size = new System.Drawing.Size(21, 24);
            this.lblSortArrow.TabIndex = 10;
            this.lblSortArrow.Text = "↓";
            this.lblSortArrow.Visible = false;
            this.lblSortArrow.Click += new System.EventHandler(this.lblSortArrow_Click);
            // 
            // pbxLoading
            // 
            this.pbxLoading.BackColor = System.Drawing.Color.Transparent;
            this.pbxLoading.Image = global::FileForensiq.UI.Properties.Resources.LoadingGif;
            this.pbxLoading.Location = new System.Drawing.Point(228, 11);
            this.pbxLoading.Margin = new System.Windows.Forms.Padding(4);
            this.pbxLoading.Name = "pbxLoading";
            this.pbxLoading.Size = new System.Drawing.Size(59, 32);
            this.pbxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxLoading.TabIndex = 4;
            this.pbxLoading.TabStop = false;
            this.pbxLoading.Visible = false;
            // 
            // btnErrorLog
            // 
            this.btnErrorLog.Location = new System.Drawing.Point(227, 532);
            this.btnErrorLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnErrorLog.Name = "btnErrorLog";
            this.btnErrorLog.Size = new System.Drawing.Size(100, 28);
            this.btnErrorLog.TabIndex = 13;
            this.btnErrorLog.Text = "⚠ Error Log";
            this.btnErrorLog.UseVisualStyleBackColor = true;
            // 
            // pnlFolderDetails
            // 
            this.pnlFolderDetails.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlFolderDetails.Controls.Add(this.lblFolderFileType);
            this.pnlFolderDetails.Controls.Add(this.lblTypeLabel);
            this.pnlFolderDetails.Controls.Add(this.lblFolderFileLastModify);
            this.pnlFolderDetails.Controls.Add(this.lblLastModifyLabel);
            this.pnlFolderDetails.Controls.Add(this.lblFileFolderLastAccess);
            this.pnlFolderDetails.Controls.Add(this.lblLastAccessLabel);
            this.pnlFolderDetails.Controls.Add(this.lblFolderFileCreated);
            this.pnlFolderDetails.Controls.Add(this.lblCreatedLabel);
            this.pnlFolderDetails.Controls.Add(this.lblFolderFileSize);
            this.pnlFolderDetails.Controls.Add(this.lblSizeLabel);
            this.pnlFolderDetails.Controls.Add(this.lblFolderFileName);
            this.pnlFolderDetails.Controls.Add(this.lblFolderFileLabel);
            this.pnlFolderDetails.Location = new System.Drawing.Point(592, 11);
            this.pnlFolderDetails.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFolderDetails.Name = "pnlFolderDetails";
            this.pnlFolderDetails.Size = new System.Drawing.Size(517, 145);
            this.pnlFolderDetails.TabIndex = 14;
            // 
            // lblFolderFileType
            // 
            this.lblFolderFileType.AutoSize = true;
            this.lblFolderFileType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileType.Location = new System.Drawing.Point(157, 78);
            this.lblFolderFileType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolderFileType.Name = "lblFolderFileType";
            this.lblFolderFileType.Size = new System.Drawing.Size(35, 18);
            this.lblFolderFileType.TabIndex = 11;
            this.lblFolderFileType.Text = "type";
            this.lblFolderFileType.Visible = false;
            // 
            // lblTypeLabel
            // 
            this.lblTypeLabel.AutoSize = true;
            this.lblTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeLabel.Location = new System.Drawing.Point(89, 78);
            this.lblTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTypeLabel.Name = "lblTypeLabel";
            this.lblTypeLabel.Size = new System.Drawing.Size(49, 18);
            this.lblTypeLabel.TabIndex = 10;
            this.lblTypeLabel.Text = "Type:";
            // 
            // lblFolderFileLastModify
            // 
            this.lblFolderFileLastModify.AutoSize = true;
            this.lblFolderFileLastModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileLastModify.Location = new System.Drawing.Point(356, 108);
            this.lblFolderFileLastModify.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolderFileLastModify.Name = "lblFolderFileLastModify";
            this.lblFolderFileLastModify.Size = new System.Drawing.Size(79, 18);
            this.lblFolderFileLastModify.TabIndex = 9;
            this.lblFolderFileLastModify.Text = "last modify";
            this.lblFolderFileLastModify.Visible = false;
            // 
            // lblLastModifyLabel
            // 
            this.lblLastModifyLabel.AutoSize = true;
            this.lblLastModifyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastModifyLabel.Location = new System.Drawing.Point(232, 108);
            this.lblLastModifyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastModifyLabel.Name = "lblLastModifyLabel";
            this.lblLastModifyLabel.Size = new System.Drawing.Size(100, 18);
            this.lblLastModifyLabel.TabIndex = 8;
            this.lblLastModifyLabel.Text = "Last modify:";
            // 
            // lblFileFolderLastAccess
            // 
            this.lblFileFolderLastAccess.AutoSize = true;
            this.lblFileFolderLastAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileFolderLastAccess.Location = new System.Drawing.Point(356, 78);
            this.lblFileFolderLastAccess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileFolderLastAccess.Name = "lblFileFolderLastAccess";
            this.lblFileFolderLastAccess.Size = new System.Drawing.Size(83, 18);
            this.lblFileFolderLastAccess.TabIndex = 7;
            this.lblFileFolderLastAccess.Text = "last access";
            this.lblFileFolderLastAccess.Visible = false;
            // 
            // lblLastAccessLabel
            // 
            this.lblLastAccessLabel.AutoSize = true;
            this.lblLastAccessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastAccessLabel.Location = new System.Drawing.Point(229, 78);
            this.lblLastAccessLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastAccessLabel.Name = "lblLastAccessLabel";
            this.lblLastAccessLabel.Size = new System.Drawing.Size(104, 18);
            this.lblLastAccessLabel.TabIndex = 6;
            this.lblLastAccessLabel.Text = "Last access:";
            // 
            // lblFolderFileCreated
            // 
            this.lblFolderFileCreated.AutoSize = true;
            this.lblFolderFileCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileCreated.Location = new System.Drawing.Point(356, 48);
            this.lblFolderFileCreated.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolderFileCreated.Name = "lblFolderFileCreated";
            this.lblFolderFileCreated.Size = new System.Drawing.Size(57, 18);
            this.lblFolderFileCreated.TabIndex = 5;
            this.lblFolderFileCreated.Text = "created";
            this.lblFolderFileCreated.Visible = false;
            // 
            // lblCreatedLabel
            // 
            this.lblCreatedLabel.AutoSize = true;
            this.lblCreatedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedLabel.Location = new System.Drawing.Point(263, 48);
            this.lblCreatedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreatedLabel.Name = "lblCreatedLabel";
            this.lblCreatedLabel.Size = new System.Drawing.Size(72, 18);
            this.lblCreatedLabel.TabIndex = 4;
            this.lblCreatedLabel.Text = "Created:";
            // 
            // lblFolderFileSize
            // 
            this.lblFolderFileSize.AutoSize = true;
            this.lblFolderFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileSize.Location = new System.Drawing.Point(156, 48);
            this.lblFolderFileSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolderFileSize.Name = "lblFolderFileSize";
            this.lblFolderFileSize.Size = new System.Drawing.Size(35, 18);
            this.lblFolderFileSize.TabIndex = 3;
            this.lblFolderFileSize.Text = "size";
            this.lblFolderFileSize.Visible = false;
            // 
            // lblSizeLabel
            // 
            this.lblSizeLabel.AutoSize = true;
            this.lblSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeLabel.Location = new System.Drawing.Point(93, 48);
            this.lblSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSizeLabel.Name = "lblSizeLabel";
            this.lblSizeLabel.Size = new System.Drawing.Size(46, 18);
            this.lblSizeLabel.TabIndex = 2;
            this.lblSizeLabel.Text = "Size:";
            // 
            // lblFolderFileName
            // 
            this.lblFolderFileName.AutoSize = true;
            this.lblFolderFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileName.Location = new System.Drawing.Point(155, 17);
            this.lblFolderFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolderFileName.Name = "lblFolderFileName";
            this.lblFolderFileName.Size = new System.Drawing.Size(50, 20);
            this.lblFolderFileName.TabIndex = 1;
            this.lblFolderFileName.Text = "name";
            this.lblFolderFileName.Visible = false;
            // 
            // lblFolderFileLabel
            // 
            this.lblFolderFileLabel.AutoSize = true;
            this.lblFolderFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileLabel.Location = new System.Drawing.Point(17, 14);
            this.lblFolderFileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolderFileLabel.Name = "lblFolderFileLabel";
            this.lblFolderFileLabel.Size = new System.Drawing.Size(122, 25);
            this.lblFolderFileLabel.TabIndex = 0;
            this.lblFolderFileLabel.Text = "Folder/File:";
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToOrderColumns = true;
            this.dgvFiles.AllowUserToResizeRows = false;
            this.dgvFiles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFileName,
            this.colType,
            this.colLength,
            this.colTimeCreated,
            this.colLastAccess,
            this.colLastModify});
            this.dgvFiles.Location = new System.Drawing.Point(592, 178);
            this.dgvFiles.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.RowHeadersWidth = 51;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(517, 345);
            this.dgvFiles.TabIndex = 15;
            // 
            // colFileName
            // 
            this.colFileName.DataPropertyName = "Name";
            this.colFileName.Frozen = true;
            this.colFileName.HeaderText = "Name:";
            this.colFileName.MinimumWidth = 6;
            this.colFileName.Name = "colFileName";
            this.colFileName.ReadOnly = true;
            this.colFileName.Width = 125;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colType.DataPropertyName = "Extension";
            this.colType.HeaderText = "Type:";
            this.colType.MinimumWidth = 6;
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 73;
            // 
            // colLength
            // 
            this.colLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLength.DataPropertyName = "Length";
            this.colLength.HeaderText = "Size:";
            this.colLength.MinimumWidth = 6;
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Width = 68;
            // 
            // colTimeCreated
            // 
            this.colTimeCreated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTimeCreated.HeaderText = "Time Created:";
            this.colTimeCreated.MinimumWidth = 6;
            this.colTimeCreated.Name = "colTimeCreated";
            this.colTimeCreated.ReadOnly = true;
            this.colTimeCreated.Width = 126;
            // 
            // colLastAccess
            // 
            this.colLastAccess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLastAccess.HeaderText = "Last Access:";
            this.colLastAccess.MinimumWidth = 6;
            this.colLastAccess.Name = "colLastAccess";
            this.colLastAccess.ReadOnly = true;
            this.colLastAccess.Width = 117;
            // 
            // colLastModify
            // 
            this.colLastModify.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLastModify.HeaderText = "Last Modify:";
            this.colLastModify.MinimumWidth = 6;
            this.colLastModify.Name = "colLastModify";
            this.colLastModify.ReadOnly = true;
            this.colLastModify.Width = 113;
            // 
            // lblLastCache
            // 
            this.lblLastCache.AutoSize = true;
            this.lblLastCache.Location = new System.Drawing.Point(590, 540);
            this.lblLastCache.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastCache.Name = "lblLastCache";
            this.lblLastCache.Size = new System.Drawing.Size(104, 17);
            this.lblLastCache.TabIndex = 17;
            this.lblLastCache.Text = "last cache date";
            this.lblLastCache.Visible = false;
            // 
            // lblLastCacheLabel
            // 
            this.lblLastCacheLabel.AutoSize = true;
            this.lblLastCacheLabel.Location = new System.Drawing.Point(509, 540);
            this.lblLastCacheLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastCacheLabel.Name = "lblLastCacheLabel";
            this.lblLastCacheLabel.Size = new System.Drawing.Size(81, 17);
            this.lblLastCacheLabel.TabIndex = 16;
            this.lblLastCacheLabel.Text = "Last cache:";
            this.lblLastCacheLabel.Visible = false;
            // 
            // bgwCache
            // 
            this.bgwCache.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCache_DoWork);
            this.bgwCache.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCache_RunWorkerCompleted);
            // 
            // cbxCacheEvery
            // 
            this.cbxCacheEvery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCacheEvery.FormattingEnabled = true;
            this.cbxCacheEvery.Items.AddRange(new object[] {
            "10 minutes",
            "30 minutes",
            "60 minutes"});
            this.cbxCacheEvery.Location = new System.Drawing.Point(117, 533);
            this.cbxCacheEvery.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCacheEvery.Name = "cbxCacheEvery";
            this.cbxCacheEvery.Size = new System.Drawing.Size(100, 24);
            this.cbxCacheEvery.TabIndex = 20;
            this.cbxCacheEvery.SelectedIndexChanged += new System.EventHandler(this.cbxCacheEvery_SelectedIndexChanged);
            // 
            // lblCacheEveryLabel
            // 
            this.lblCacheEveryLabel.AutoSize = true;
            this.lblCacheEveryLabel.Location = new System.Drawing.Point(16, 538);
            this.lblCacheEveryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCacheEveryLabel.Name = "lblCacheEveryLabel";
            this.lblCacheEveryLabel.Size = new System.Drawing.Size(91, 17);
            this.lblCacheEveryLabel.TabIndex = 21;
            this.lblCacheEveryLabel.Text = "Cache every:";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1129, 570);
            this.Controls.Add(this.lblCacheEveryLabel);
            this.Controls.Add(this.cbxCacheEvery);
            this.Controls.Add(this.lblLastCache);
            this.Controls.Add(this.lblLastCacheLabel);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.pnlFolderDetails);
            this.Controls.Add(this.btnErrorLog);
            this.Controls.Add(this.lblSortArrow);
            this.Controls.Add(this.lblMemoryMB);
            this.Controls.Add(this.lblMemoryUsage);
            this.Controls.Add(this.cbxSortBy);
            this.Controls.Add(this.lblSort);
            this.Controls.Add(this.pbxLoading);
            this.Controls.Add(this.cbxPartitionLetters);
            this.Controls.Add(this.tvFileSystem);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Forensiq";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoading)).EndInit();
            this.pnlFolderDetails.ResumeLayout(false);
            this.pnlFolderDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TreeView tvFileSystem;
        private System.Windows.Forms.ComboBox cbxPartitionLetters;
        private System.Windows.Forms.PictureBox pbxLoading;
        private System.Windows.Forms.ImageList imglFilesIcons;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cbxSortBy;
        private System.Windows.Forms.Label lblMemoryUsage;
        private System.Windows.Forms.Label lblMemoryMB;
        private System.Windows.Forms.Label lblSortArrow;
        private System.Windows.Forms.Button btnErrorLog;
        private System.Windows.Forms.Panel pnlFolderDetails;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.Label lblFolderFileType;
        private System.Windows.Forms.Label lblTypeLabel;
        private System.Windows.Forms.Label lblFolderFileLastModify;
        private System.Windows.Forms.Label lblLastModifyLabel;
        private System.Windows.Forms.Label lblFileFolderLastAccess;
        private System.Windows.Forms.Label lblLastAccessLabel;
        private System.Windows.Forms.Label lblFolderFileCreated;
        private System.Windows.Forms.Label lblCreatedLabel;
        private System.Windows.Forms.Label lblFolderFileSize;
        private System.Windows.Forms.Label lblSizeLabel;
        private System.Windows.Forms.Label lblFolderFileName;
        private System.Windows.Forms.Label lblFolderFileLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastAccess;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastModify;
        private System.Windows.Forms.Label lblLastCache;
        private System.Windows.Forms.Label lblLastCacheLabel;
        private System.ComponentModel.BackgroundWorker bgwCache;
        private System.Windows.Forms.ComboBox cbxCacheEvery;
        private System.Windows.Forms.Label lblCacheEveryLabel;
        private System.Windows.Forms.Timer timer;
    }
}

