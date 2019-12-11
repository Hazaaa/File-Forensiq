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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblResultStats = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.cbxDriveLetters = new System.Windows.Forms.ComboBox();
            this.pbxLoading = new System.Windows.Forms.PictureBox();
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
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 71);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(419, 333);
            this.treeView1.TabIndex = 2;
            // 
            // cbxDriveLetters
            // 
            this.cbxDriveLetters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDriveLetters.FormattingEnabled = true;
            this.cbxDriveLetters.Location = new System.Drawing.Point(12, 12);
            this.cbxDriveLetters.Name = "cbxDriveLetters";
            this.cbxDriveLetters.Size = new System.Drawing.Size(65, 21);
            this.cbxDriveLetters.TabIndex = 3;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(747, 416);
            this.Controls.Add(this.pbxLoading);
            this.Controls.Add(this.cbxDriveLetters);
            this.Controls.Add(this.treeView1);
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
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ComboBox cbxDriveLetters;
        private System.Windows.Forms.PictureBox pbxLoading;
    }
}

