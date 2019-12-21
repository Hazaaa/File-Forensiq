namespace FileForensiq.UI
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
            this.lblResultStats = new System.Windows.Forms.Label();
            this.tvFileSystem = new System.Windows.Forms.TreeView();
            this.imglFilesIcons = new System.Windows.Forms.ImageList(this.components);
            this.cbxPartitionLetters = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.cbxSortBy = new System.Windows.Forms.ComboBox();
            this.lblMemoryUsage = new System.Windows.Forms.Label();
            this.lblMemoryMB = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblSortArrow = new System.Windows.Forms.Label();
            this.pbxLoading = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoading)).BeginInit();
            this.pnlFolderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(83, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Process";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblResultStats
            // 
            this.lblResultStats.AutoSize = true;
            this.lblResultStats.Location = new System.Drawing.Point(10, 45);
            this.lblResultStats.Name = "lblResultStats";
            this.lblResultStats.Size = new System.Drawing.Size(94, 13);
            this.lblResultStats.TabIndex = 1;
            this.lblResultStats.Text = "Search result stats";
            this.lblResultStats.Visible = false;
            // 
            // tvFileSystem
            // 
            this.tvFileSystem.ImageIndex = 0;
            this.tvFileSystem.ImageList = this.imglFilesIcons;
            this.tvFileSystem.Location = new System.Drawing.Point(12, 93);
            this.tvFileSystem.Name = "tvFileSystem";
            this.tvFileSystem.SelectedImageIndex = 0;
            this.tvFileSystem.Size = new System.Drawing.Size(419, 333);
            this.tvFileSystem.TabIndex = 2;
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
            this.cbxPartitionLetters.Location = new System.Drawing.Point(12, 12);
            this.cbxPartitionLetters.Name = "cbxPartitionLetters";
            this.cbxPartitionLetters.Size = new System.Drawing.Size(65, 21);
            this.cbxPartitionLetters.TabIndex = 3;
            this.cbxPartitionLetters.Click += new System.EventHandler(this.cbxPartitionLetters_Click);
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(10, 70);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(43, 13);
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
            this.cbxSortBy.Location = new System.Drawing.Point(59, 66);
            this.cbxSortBy.Name = "cbxSortBy";
            this.cbxSortBy.Size = new System.Drawing.Size(100, 21);
            this.cbxSortBy.TabIndex = 6;
            this.cbxSortBy.SelectedIndexChanged += new System.EventHandler(this.cbxSortBy_SelectedIndexChanged);
            // 
            // lblMemoryUsage
            // 
            this.lblMemoryUsage.AutoSize = true;
            this.lblMemoryUsage.Location = new System.Drawing.Point(150, 437);
            this.lblMemoryUsage.Name = "lblMemoryUsage";
            this.lblMemoryUsage.Size = new System.Drawing.Size(79, 13);
            this.lblMemoryUsage.TabIndex = 7;
            this.lblMemoryUsage.Text = "Memory usage:";
            // 
            // lblMemoryMB
            // 
            this.lblMemoryMB.AutoSize = true;
            this.lblMemoryMB.Location = new System.Drawing.Point(228, 438);
            this.lblMemoryMB.Name = "lblMemoryMB";
            this.lblMemoryMB.Size = new System.Drawing.Size(74, 13);
            this.lblMemoryMB.TabIndex = 8;
            this.lblMemoryMB.Text = "Memory in MB";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblSortArrow
            // 
            this.lblSortArrow.AutoSize = true;
            this.lblSortArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSortArrow.Location = new System.Drawing.Point(163, 66);
            this.lblSortArrow.Name = "lblSortArrow";
            this.lblSortArrow.Size = new System.Drawing.Size(17, 18);
            this.lblSortArrow.TabIndex = 10;
            this.lblSortArrow.Text = "↓";
            this.lblSortArrow.Visible = false;
            this.lblSortArrow.Click += new System.EventHandler(this.lblSortArrow_Click);
            // 
            // pbxLoading
            // 
            this.pbxLoading.BackColor = System.Drawing.Color.Transparent;
            this.pbxLoading.Image = global::FileForensiq.UI.Properties.Resources.LoadingGif;
            this.pbxLoading.Location = new System.Drawing.Point(171, 9);
            this.pbxLoading.Name = "pbxLoading";
            this.pbxLoading.Size = new System.Drawing.Size(44, 26);
            this.pbxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxLoading.TabIndex = 4;
            this.pbxLoading.TabStop = false;
            this.pbxLoading.Visible = false;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(12, 432);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(64, 23);
            this.btnSettings.TabIndex = 11;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnErrorLog
            // 
            this.btnErrorLog.Location = new System.Drawing.Point(80, 432);
            this.btnErrorLog.Name = "btnErrorLog";
            this.btnErrorLog.Size = new System.Drawing.Size(64, 23);
            this.btnErrorLog.TabIndex = 13;
            this.btnErrorLog.Text = "Error Log";
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
            this.pnlFolderDetails.Location = new System.Drawing.Point(444, 9);
            this.pnlFolderDetails.Name = "pnlFolderDetails";
            this.pnlFolderDetails.Size = new System.Drawing.Size(388, 118);
            this.pnlFolderDetails.TabIndex = 14;
            // 
            // lblFolderFileType
            // 
            this.lblFolderFileType.AutoSize = true;
            this.lblFolderFileType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileType.Location = new System.Drawing.Point(118, 63);
            this.lblFolderFileType.Name = "lblFolderFileType";
            this.lblFolderFileType.Size = new System.Drawing.Size(29, 15);
            this.lblFolderFileType.TabIndex = 11;
            this.lblFolderFileType.Text = "type";
            this.lblFolderFileType.Visible = false;
            // 
            // lblTypeLabel
            // 
            this.lblTypeLabel.AutoSize = true;
            this.lblTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeLabel.Location = new System.Drawing.Point(67, 63);
            this.lblTypeLabel.Name = "lblTypeLabel";
            this.lblTypeLabel.Size = new System.Drawing.Size(41, 15);
            this.lblTypeLabel.TabIndex = 10;
            this.lblTypeLabel.Text = "Type:";
            // 
            // lblFolderFileLastModify
            // 
            this.lblFolderFileLastModify.AutoSize = true;
            this.lblFolderFileLastModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileLastModify.Location = new System.Drawing.Point(267, 88);
            this.lblFolderFileLastModify.Name = "lblFolderFileLastModify";
            this.lblFolderFileLastModify.Size = new System.Drawing.Size(65, 15);
            this.lblFolderFileLastModify.TabIndex = 9;
            this.lblFolderFileLastModify.Text = "last modify";
            this.lblFolderFileLastModify.Visible = false;
            // 
            // lblLastModifyLabel
            // 
            this.lblLastModifyLabel.AutoSize = true;
            this.lblLastModifyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastModifyLabel.Location = new System.Drawing.Point(174, 88);
            this.lblLastModifyLabel.Name = "lblLastModifyLabel";
            this.lblLastModifyLabel.Size = new System.Drawing.Size(84, 15);
            this.lblLastModifyLabel.TabIndex = 8;
            this.lblLastModifyLabel.Text = "Last modify:";
            // 
            // lblFileFolderLastAccess
            // 
            this.lblFileFolderLastAccess.AutoSize = true;
            this.lblFileFolderLastAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileFolderLastAccess.Location = new System.Drawing.Point(267, 63);
            this.lblFileFolderLastAccess.Name = "lblFileFolderLastAccess";
            this.lblFileFolderLastAccess.Size = new System.Drawing.Size(67, 15);
            this.lblFileFolderLastAccess.TabIndex = 7;
            this.lblFileFolderLastAccess.Text = "last access";
            this.lblFileFolderLastAccess.Visible = false;
            // 
            // lblLastAccessLabel
            // 
            this.lblLastAccessLabel.AutoSize = true;
            this.lblLastAccessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastAccessLabel.Location = new System.Drawing.Point(172, 63);
            this.lblLastAccessLabel.Name = "lblLastAccessLabel";
            this.lblLastAccessLabel.Size = new System.Drawing.Size(86, 15);
            this.lblLastAccessLabel.TabIndex = 6;
            this.lblLastAccessLabel.Text = "Last access:";
            // 
            // lblFolderFileCreated
            // 
            this.lblFolderFileCreated.AutoSize = true;
            this.lblFolderFileCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileCreated.Location = new System.Drawing.Point(267, 39);
            this.lblFolderFileCreated.Name = "lblFolderFileCreated";
            this.lblFolderFileCreated.Size = new System.Drawing.Size(48, 15);
            this.lblFolderFileCreated.TabIndex = 5;
            this.lblFolderFileCreated.Text = "created";
            this.lblFolderFileCreated.Visible = false;
            // 
            // lblCreatedLabel
            // 
            this.lblCreatedLabel.AutoSize = true;
            this.lblCreatedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedLabel.Location = new System.Drawing.Point(197, 39);
            this.lblCreatedLabel.Name = "lblCreatedLabel";
            this.lblCreatedLabel.Size = new System.Drawing.Size(61, 15);
            this.lblCreatedLabel.TabIndex = 4;
            this.lblCreatedLabel.Text = "Created:";
            // 
            // lblFolderFileSize
            // 
            this.lblFolderFileSize.AutoSize = true;
            this.lblFolderFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileSize.Location = new System.Drawing.Point(117, 39);
            this.lblFolderFileSize.Name = "lblFolderFileSize";
            this.lblFolderFileSize.Size = new System.Drawing.Size(29, 15);
            this.lblFolderFileSize.TabIndex = 3;
            this.lblFolderFileSize.Text = "size";
            this.lblFolderFileSize.Visible = false;
            // 
            // lblSizeLabel
            // 
            this.lblSizeLabel.AutoSize = true;
            this.lblSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeLabel.Location = new System.Drawing.Point(70, 39);
            this.lblSizeLabel.Name = "lblSizeLabel";
            this.lblSizeLabel.Size = new System.Drawing.Size(39, 15);
            this.lblSizeLabel.TabIndex = 2;
            this.lblSizeLabel.Text = "Size:";
            // 
            // lblFolderFileName
            // 
            this.lblFolderFileName.AutoSize = true;
            this.lblFolderFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileName.Location = new System.Drawing.Point(116, 14);
            this.lblFolderFileName.Name = "lblFolderFileName";
            this.lblFolderFileName.Size = new System.Drawing.Size(42, 16);
            this.lblFolderFileName.TabIndex = 1;
            this.lblFolderFileName.Text = "name";
            this.lblFolderFileName.Visible = false;
            // 
            // lblFolderFileLabel
            // 
            this.lblFolderFileLabel.AutoSize = true;
            this.lblFolderFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileLabel.Location = new System.Drawing.Point(13, 11);
            this.lblFolderFileLabel.Name = "lblFolderFileLabel";
            this.lblFolderFileLabel.Size = new System.Drawing.Size(99, 20);
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
            this.dgvFiles.Location = new System.Drawing.Point(444, 145);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(388, 280);
            this.dgvFiles.TabIndex = 15;
            // 
            // colFileName
            // 
            this.colFileName.DataPropertyName = "Name";
            this.colFileName.Frozen = true;
            this.colFileName.HeaderText = "Name:";
            this.colFileName.Name = "colFileName";
            this.colFileName.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colType.DataPropertyName = "Extension";
            this.colType.HeaderText = "Type:";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 59;
            // 
            // colLength
            // 
            this.colLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLength.DataPropertyName = "Length";
            this.colLength.HeaderText = "Size:";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Width = 55;
            // 
            // colTimeCreated
            // 
            this.colTimeCreated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTimeCreated.HeaderText = "Time Created:";
            this.colTimeCreated.Name = "colTimeCreated";
            this.colTimeCreated.ReadOnly = true;
            this.colTimeCreated.Width = 98;
            // 
            // colLastAccess
            // 
            this.colLastAccess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLastAccess.HeaderText = "Last Access:";
            this.colLastAccess.Name = "colLastAccess";
            this.colLastAccess.ReadOnly = true;
            this.colLastAccess.Width = 93;
            // 
            // colLastModify
            // 
            this.colLastModify.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLastModify.HeaderText = "Last Modify:";
            this.colLastModify.Name = "colLastModify";
            this.colLastModify.ReadOnly = true;
            this.colLastModify.Width = 89;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(847, 463);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.pnlFolderDetails);
            this.Controls.Add(this.btnErrorLog);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lblSortArrow);
            this.Controls.Add(this.lblMemoryMB);
            this.Controls.Add(this.lblMemoryUsage);
            this.Controls.Add(this.cbxSortBy);
            this.Controls.Add(this.lblSort);
            this.Controls.Add(this.pbxLoading);
            this.Controls.Add(this.cbxPartitionLetters);
            this.Controls.Add(this.tvFileSystem);
            this.Controls.Add(this.lblResultStats);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Label lblResultStats;
        private System.Windows.Forms.TreeView tvFileSystem;
        private System.Windows.Forms.ComboBox cbxPartitionLetters;
        private System.Windows.Forms.PictureBox pbxLoading;
        private System.Windows.Forms.ImageList imglFilesIcons;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cbxSortBy;
        private System.Windows.Forms.Label lblMemoryUsage;
        private System.Windows.Forms.Label lblMemoryMB;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblSortArrow;
        private System.Windows.Forms.Button btnSettings;
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
    }
}

