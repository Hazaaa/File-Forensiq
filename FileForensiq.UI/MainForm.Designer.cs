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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pbxFilePicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoading)).BeginInit();
            this.pnlFolderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFilePicture)).BeginInit();
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
            this.pnlFolderDetails.Controls.Add(this.pbxFilePicture);
            this.pnlFolderDetails.Location = new System.Drawing.Point(444, 9);
            this.pnlFolderDetails.Name = "pnlFolderDetails";
            this.pnlFolderDetails.Size = new System.Drawing.Size(388, 111);
            this.pnlFolderDetails.TabIndex = 14;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(446, 137);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(386, 288);
            this.dataGridView1.TabIndex = 15;
            // 
            // pbxFilePicture
            // 
            this.pbxFilePicture.Location = new System.Drawing.Point(3, 3);
            this.pbxFilePicture.Name = "pbxFilePicture";
            this.pbxFilePicture.Size = new System.Drawing.Size(63, 57);
            this.pbxFilePicture.TabIndex = 16;
            this.pbxFilePicture.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(847, 463);
            this.Controls.Add(this.dataGridView1);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFilePicture)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pbxFilePicture;
    }
}

