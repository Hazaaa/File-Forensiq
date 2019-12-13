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
            this.cbxDriveLetters = new System.Windows.Forms.ComboBox();
            this.pbxLoading = new System.Windows.Forms.PictureBox();
            this.imglFilesIcons = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoading)).BeginInit();
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
            this.lblResultStats.Location = new System.Drawing.Point(9, 45);
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
            this.tvFileSystem.Location = new System.Drawing.Point(12, 71);
            this.tvFileSystem.Name = "tvFileSystem";
            this.tvFileSystem.SelectedImageIndex = 0;
            this.tvFileSystem.Size = new System.Drawing.Size(419, 333);
            this.tvFileSystem.TabIndex = 2;
            // 
            // cbxDriveLetters
            // 
            this.cbxDriveLetters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDriveLetters.FormattingEnabled = true;
            this.cbxDriveLetters.Location = new System.Drawing.Point(12, 12);
            this.cbxDriveLetters.Name = "cbxDriveLetters";
            this.cbxDriveLetters.Size = new System.Drawing.Size(65, 21);
            this.cbxDriveLetters.TabIndex = 3;
            this.cbxDriveLetters.Click += new System.EventHandler(this.cbxDriveLetters_Click);
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
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(747, 416);
            this.Controls.Add(this.pbxLoading);
            this.Controls.Add(this.cbxDriveLetters);
            this.Controls.Add(this.tvFileSystem);
            this.Controls.Add(this.lblResultStats);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Forensiq";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblResultStats;
        private System.Windows.Forms.TreeView tvFileSystem;
        private System.Windows.Forms.ComboBox cbxDriveLetters;
        private System.Windows.Forms.PictureBox pbxLoading;
        private System.Windows.Forms.ImageList imglFilesIcons;
    }
}

