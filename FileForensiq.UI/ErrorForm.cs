using FileForensiq.Core.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileForensiq.UI
{
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            foreach (var error in ErrorLogger.GetAllErrors())
            {
                if(error == "")
                {
                    continue;
                }

                var text = error.Split('/');
                int row = dgwErrors.Rows.Count;
                dgwErrors.Rows.Add();
                dgwErrors.Rows[row].Cells[0].Value = text[0].ToString();
                dgwErrors.Rows[row].Cells[1].Value = text[1];
            }
        }
    }
}
