namespace FileForensiq.UI
{
    partial class FilterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterForm));
            this.clbFileTypes = new System.Windows.Forms.CheckedListBox();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.gbxTimePeriod = new System.Windows.Forms.GroupBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.gbxFileType = new System.Windows.Forms.GroupBox();
            this.gbxFilterOptions = new System.Windows.Forms.GroupBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.cbxFilterPeriod = new System.Windows.Forms.ComboBox();
            this.lblOption = new System.Windows.Forms.Label();
            this.cbxFilterOptions = new System.Windows.Forms.ComboBox();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.gbxFiles = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumberOfFiles = new System.Windows.Forms.Label();
            this.lblNumOfFiles = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblErrorLabel = new System.Windows.Forms.Label();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbxTimePeriod.SuspendLayout();
            this.gbxFileType.SuspendLayout();
            this.gbxFilterOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.gbxFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbFileTypes
            // 
            this.clbFileTypes.FormattingEnabled = true;
            this.clbFileTypes.Items.AddRange(new object[] {
            "All"});
            this.clbFileTypes.Location = new System.Drawing.Point(21, 24);
            this.clbFileTypes.Name = "clbFileTypes";
            this.clbFileTypes.Size = new System.Drawing.Size(120, 139);
            this.clbFileTypes.TabIndex = 0;
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(7, 47);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.Size = new System.Drawing.Size(120, 20);
            this.dtpPeriodFrom.TabIndex = 1;
            this.dtpPeriodFrom.Value = new System.DateTime(2020, 1, 17, 14, 23, 2, 0);
            // 
            // gbxTimePeriod
            // 
            this.gbxTimePeriod.Controls.Add(this.lblTo);
            this.gbxTimePeriod.Controls.Add(this.dtpPeriodTo);
            this.gbxTimePeriod.Controls.Add(this.lblFrom);
            this.gbxTimePeriod.Controls.Add(this.dtpPeriodFrom);
            this.gbxTimePeriod.Location = new System.Drawing.Point(312, 12);
            this.gbxTimePeriod.Name = "gbxTimePeriod";
            this.gbxTimePeriod.Size = new System.Drawing.Size(280, 81);
            this.gbxTimePeriod.TabIndex = 3;
            this.gbxTimePeriod.TabStop = false;
            this.gbxTimePeriod.Text = "Time Period:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(148, 26);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "To:";
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodTo.Location = new System.Drawing.Point(148, 47);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.Size = new System.Drawing.Size(120, 20);
            this.dtpPeriodTo.TabIndex = 3;
            this.dtpPeriodTo.Value = new System.DateTime(2020, 1, 17, 14, 23, 2, 0);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(7, 26);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "From:";
            // 
            // gbxFileType
            // 
            this.gbxFileType.Controls.Add(this.clbFileTypes);
            this.gbxFileType.Location = new System.Drawing.Point(611, 12);
            this.gbxFileType.Name = "gbxFileType";
            this.gbxFileType.Size = new System.Drawing.Size(158, 174);
            this.gbxFileType.TabIndex = 4;
            this.gbxFileType.TabStop = false;
            this.gbxFileType.Text = "File Type:";
            // 
            // gbxFilterOptions
            // 
            this.gbxFilterOptions.Controls.Add(this.lblPeriod);
            this.gbxFilterOptions.Controls.Add(this.cbxFilterPeriod);
            this.gbxFilterOptions.Controls.Add(this.lblOption);
            this.gbxFilterOptions.Controls.Add(this.cbxFilterOptions);
            this.gbxFilterOptions.Location = new System.Drawing.Point(12, 12);
            this.gbxFilterOptions.Name = "gbxFilterOptions";
            this.gbxFilterOptions.Size = new System.Drawing.Size(281, 81);
            this.gbxFilterOptions.TabIndex = 5;
            this.gbxFilterOptions.TabStop = false;
            this.gbxFilterOptions.Text = "Filter Options:";
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(146, 24);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(40, 13);
            this.lblPeriod.TabIndex = 5;
            this.lblPeriod.Text = "Period:";
            // 
            // cbxFilterPeriod
            // 
            this.cbxFilterPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilterPeriod.FormattingEnabled = true;
            this.cbxFilterPeriod.Items.AddRange(new object[] {
            "For Day",
            "For Period",
            "For 30 Days"});
            this.cbxFilterPeriod.Location = new System.Drawing.Point(146, 42);
            this.cbxFilterPeriod.Name = "cbxFilterPeriod";
            this.cbxFilterPeriod.Size = new System.Drawing.Size(121, 21);
            this.cbxFilterPeriod.TabIndex = 4;
            this.cbxFilterPeriod.SelectedIndexChanged += new System.EventHandler(this.cbxFilterPeriod_SelectedIndexChanged);
            // 
            // lblOption
            // 
            this.lblOption.AutoSize = true;
            this.lblOption.Location = new System.Drawing.Point(6, 25);
            this.lblOption.Name = "lblOption";
            this.lblOption.Size = new System.Drawing.Size(41, 13);
            this.lblOption.TabIndex = 3;
            this.lblOption.Text = "Option:";
            // 
            // cbxFilterOptions
            // 
            this.cbxFilterOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilterOptions.FormattingEnabled = true;
            this.cbxFilterOptions.Items.AddRange(new object[] {
            "Show All",
            "Time Created",
            "Last Modify Time",
            "Last Access Time"});
            this.cbxFilterOptions.Location = new System.Drawing.Point(6, 43);
            this.cbxFilterOptions.Name = "cbxFilterOptions";
            this.cbxFilterOptions.Size = new System.Drawing.Size(121, 21);
            this.cbxFilterOptions.TabIndex = 0;
            this.cbxFilterOptions.SelectedIndexChanged += new System.EventHandler(this.cbxFilterOptions_SelectedIndexChanged);
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToOrderColumns = true;
            this.dgvFiles.AllowUserToResizeRows = false;
            this.dgvFiles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Location = new System.Drawing.Point(13, 51);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.RowHeadersWidth = 51;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(555, 288);
            this.dgvFiles.TabIndex = 16;
            this.dgvFiles.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellContentDoubleClick);
            this.dgvFiles.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFiles_ColumnHeaderMouseClick);
            // 
            // gbxFiles
            // 
            this.gbxFiles.Controls.Add(this.label2);
            this.gbxFiles.Controls.Add(this.tbxSearch);
            this.gbxFiles.Controls.Add(this.label1);
            this.gbxFiles.Controls.Add(this.lblNumberOfFiles);
            this.gbxFiles.Controls.Add(this.lblNumOfFiles);
            this.gbxFiles.Controls.Add(this.dgvFiles);
            this.gbxFiles.Location = new System.Drawing.Point(12, 99);
            this.gbxFiles.Name = "gbxFiles";
            this.gbxFiles.Size = new System.Drawing.Size(580, 373);
            this.gbxFiles.TabIndex = 17;
            this.gbxFiles.TabStop = false;
            this.gbxFiles.Text = "Files:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "*Double Click on any row to open file statistics";
            // 
            // lblNumberOfFiles
            // 
            this.lblNumberOfFiles.AutoSize = true;
            this.lblNumberOfFiles.Location = new System.Drawing.Point(97, 347);
            this.lblNumberOfFiles.Name = "lblNumberOfFiles";
            this.lblNumberOfFiles.Size = new System.Drawing.Size(42, 13);
            this.lblNumberOfFiles.TabIndex = 18;
            this.lblNumberOfFiles.Text = "number";
            this.lblNumberOfFiles.Visible = false;
            // 
            // lblNumOfFiles
            // 
            this.lblNumOfFiles.AutoSize = true;
            this.lblNumOfFiles.Location = new System.Drawing.Point(10, 347);
            this.lblNumOfFiles.Name = "lblNumOfFiles";
            this.lblNumOfFiles.Size = new System.Drawing.Size(85, 13);
            this.lblNumOfFiles.TabIndex = 17;
            this.lblNumOfFiles.Text = "Number Of Files:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(611, 202);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(158, 23);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblErrorLabel
            // 
            this.lblErrorLabel.AutoSize = true;
            this.lblErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.lblErrorLabel.Location = new System.Drawing.Point(602, 228);
            this.lblErrorLabel.Name = "lblErrorLabel";
            this.lblErrorLabel.Size = new System.Drawing.Size(182, 26);
            this.lblErrorLabel.TabIndex = 19;
            this.lblErrorLabel.Text = "                 Error occurred! \r\nCheck Error Log for more information.";
            this.lblErrorLabel.Visible = false;
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(60, 22);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(126, 20);
            this.tbxSearch.TabIndex = 20;
            this.tbxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSearch_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Search:";
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 484);
            this.Controls.Add(this.lblErrorLabel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.gbxFiles);
            this.Controls.Add(this.gbxFilterOptions);
            this.Controls.Add(this.gbxFileType);
            this.Controls.Add(this.gbxTimePeriod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FilterForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter";
            this.Load += new System.EventHandler(this.FilterForm_Load);
            this.gbxTimePeriod.ResumeLayout(false);
            this.gbxTimePeriod.PerformLayout();
            this.gbxFileType.ResumeLayout(false);
            this.gbxFilterOptions.ResumeLayout(false);
            this.gbxFilterOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.gbxFiles.ResumeLayout(false);
            this.gbxFiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbFileTypes;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.GroupBox gbxTimePeriod;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.GroupBox gbxFileType;
        private System.Windows.Forms.GroupBox gbxFilterOptions;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.ComboBox cbxFilterPeriod;
        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.ComboBox cbxFilterOptions;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.GroupBox gbxFiles;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblNumberOfFiles;
        private System.Windows.Forms.Label lblNumOfFiles;
        private System.Windows.Forms.Label lblErrorLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSearch;
    }
}