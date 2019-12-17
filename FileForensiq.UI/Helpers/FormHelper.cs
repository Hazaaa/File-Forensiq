using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileForensiq.UI.Helpers
{
    public class FormHelper
    {
        public static void SetPartitionLettersCombobox(ComboBox cbxPartitionLetters)
        {
            //Checking if new partition appeared (e.g. USB flash inserted) and updating combobox
            string lastSelectedDriver = cbxPartitionLetters.SelectedItem?.ToString();
            var drivesLetters = Directory.GetLogicalDrives();
            cbxPartitionLetters.Items.Clear();
            cbxPartitionLetters.Items.AddRange(drivesLetters.Select(x => x.ToString()).ToArray());

            if(!String.IsNullOrEmpty(lastSelectedDriver))
            {
                cbxPartitionLetters.SelectedItem = lastSelectedDriver;
            }
            else
            {
                cbxPartitionLetters.SelectedIndex = 0;
            }
        }
    }
}
