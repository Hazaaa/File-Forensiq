using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileForensiq.Core.Models
{
    [Serializable]
    public class PartitionProcessingResult
    {
        /// <summary>
        /// Root node with all his children.
        /// </summary>
        public DirectoryTreeNode RootNode { get; set; }

        public int NumberOfFolders { get; set; }

        public int NumberOfFiles { get; set; }

        /// <summary>
        /// Number of Unauthorized errors while trying to access directories and files.
        /// </summary>
        public int UnauthorizedErrors { get; set; }

        /// <summary>
        /// Number of other errors while trying to access directories and files.
        /// </summary>
        public int OtherErrors { get; set; }

        public PartitionProcessingResult()
        {
            UnauthorizedErrors = 0;
            OtherErrors = 0;
            NumberOfFolders = 0;
            NumberOfFiles = 0;
        }
    }
}
