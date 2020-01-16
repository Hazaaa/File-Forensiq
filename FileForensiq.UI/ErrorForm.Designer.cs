namespace FileForensiq.UI
{
    partial class ErrorForm
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
            this.dgwErrors = new System.Windows.Forms.DataGridView();
            this.DateAndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgwErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwErrors
            // 
            this.dgwErrors.AllowUserToAddRows = false;
            this.dgwErrors.AllowUserToDeleteRows = false;
            this.dgwErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateAndTime,
            this.ErrorText});
            this.dgwErrors.Location = new System.Drawing.Point(9, 10);
            this.dgwErrors.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgwErrors.Name = "dgwErrors";
            this.dgwErrors.ReadOnly = true;
            this.dgwErrors.RowHeadersWidth = 51;
            this.dgwErrors.RowTemplate.Height = 24;
            this.dgwErrors.Size = new System.Drawing.Size(582, 346);
            this.dgwErrors.TabIndex = 0;
            // 
            // DateAndTime
            // 
            this.DateAndTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateAndTime.HeaderText = "Date And Time";
            this.DateAndTime.MinimumWidth = 6;
            this.DateAndTime.Name = "DateAndTime";
            this.DateAndTime.ReadOnly = true;
            this.DateAndTime.Width = 95;
            // 
            // ErrorText
            // 
            this.ErrorText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ErrorText.HeaderText = "Text";
            this.ErrorText.MinimumWidth = 6;
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.ReadOnly = true;
            this.ErrorText.Width = 53;
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.dgwErrors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ErrorForm";
            this.ShowIcon = false;
            this.Text = "Error Log";
            this.Load += new System.EventHandler(this.ErrorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwErrors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwErrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateAndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorText;
    }
}