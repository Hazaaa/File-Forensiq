using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileForensiq.Core.Models
{
    [Serializable]
    public class DirectoryTreeNode : TreeNode
    {
        public DirectoryTreeNode(string displayText) : base(displayText)
        {
            Size = 0;
            NumberOfFiles = 0;
            Expanded = false;
            SizeCalculated = false;
            NumberOfFilesCalculated = false;
        }

        /// <summary>
        /// Directory size in bytes.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Number of files in directory including his sub-directories.
        /// </summary>
        public int NumberOfFiles { get; set; }


        /// <summary>
        /// Bool that indicates if node has been expanded.
        /// </summary>
        public bool Expanded { get; set; }

        /// <summary>
        /// Bool that indicates if size of directory has been calculated.
        /// </summary>
        public bool SizeCalculated { get; set; }

        /// <summary>
        /// Bool that indicates if number of files of directory has been calculated.
        /// </summary>
        public bool NumberOfFilesCalculated { get; set; }
    }
}
