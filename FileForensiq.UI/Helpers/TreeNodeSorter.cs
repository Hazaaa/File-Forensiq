using FileForensiq.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileForensiq.UI.Helpers
{
    public enum SortBy
    {
        Name,
        Size,
        NumberOfFiles,
        TimeCreated,
        TimeLastAccessed,
        TimeLastModified
    }

    public class TreeNodeSorter : System.Collections.IComparer
    {
        public SortBy SortByMethod { get; set; }
        public bool Descending { get; set; }

        public TreeNodeSorter()
        {
            Descending = false;
        }

        public int Compare(object x, object y)
        {
            if(x is DirectoryTreeNode && y is DirectoryTreeNode)
            {
                return CompareDirectories(x as DirectoryTreeNode, y as DirectoryTreeNode);
            }

            if(!(x is DirectoryTreeNode) && !(y is DirectoryTreeNode))
            {
                return CompareFiles(x as TreeNode, y as TreeNode);
            }

            return 0;
        }

        public int CompareDirectories(DirectoryTreeNode x, DirectoryTreeNode y)
        {
            int result = 0;
            switch (SortByMethod)
            {
                case SortBy.Name:
                    result = String.Compare(x.Name, y.Name);
                    break;
                case SortBy.Size:
                    result = x.Size >= y.Size ? 1 : -1; 
                    break;
                case SortBy.NumberOfFiles:
                    result = x.NumberOfFiles >= y.NumberOfFiles ? 1 : -1;
                    break;
                case SortBy.TimeLastAccessed:
                    result = DateTime.Compare((x.Tag as DirectoryInfo).LastAccessTime, (y.Tag as DirectoryInfo).LastAccessTime);
                    break;
                case SortBy.TimeLastModified:
                    result = DateTime.Compare((x.Tag as DirectoryInfo).LastWriteTime, (y.Tag as DirectoryInfo).LastWriteTime);
                    break;
                case SortBy.TimeCreated:
                    result = DateTime.Compare((x.Tag as DirectoryInfo).CreationTime, (y.Tag as DirectoryInfo).CreationTime);
                    break;
                default:
                    break;
            }

            if (Descending && result != 0)
            {
                result *= -1;
            }

            return result;
        }

        public int CompareFiles(TreeNode x, TreeNode y)
        {
            int result = 0;
            switch (SortByMethod)
            {
                case SortBy.Name:
                    result = String.Compare(x.Name, y.Name);
                    break;
                case SortBy.Size:
                    result = (x.Tag as FileInfo).Length >= (y.Tag as FileInfo).Length ? 1 : -1;
                    break;
                case SortBy.TimeLastAccessed:
                    result = DateTime.Compare((x.Tag as FileInfo).LastAccessTime, (y.Tag as FileInfo).LastAccessTime);
                    break;
                case SortBy.TimeLastModified:
                    result = DateTime.Compare((x.Tag as FileInfo).LastWriteTime, (y.Tag as FileInfo).LastWriteTime);
                    break;
                case SortBy.TimeCreated:
                    result = DateTime.Compare((x.Tag as FileInfo).CreationTime, (y.Tag as FileInfo).CreationTime);
                    break;
                default:
                    break;
            }

            if (Descending && result != 0)
            {
                result = 2 % result + 1;
            }

            return result;
        }
    }
}
