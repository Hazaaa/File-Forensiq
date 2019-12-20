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

        public static void SortTreeView(ComboBox cbxSortBy, TreeView tvFileSystem, bool sortDescending)
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
    }
}
