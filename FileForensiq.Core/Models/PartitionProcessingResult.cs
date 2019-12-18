﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileForensiq.Core.Models
{
    public class PartitionProcessingResult
    {
        /// <summary>
        /// Root node with all his children.
        /// </summary>
        public DirectoryTreeNode RootNode { get; set; }

        public int NumberOfReturnedResults { get; set; }

        /// <summary>
        /// Number of Unauthorized errors while trying to access directories and files.
        /// </summary>
        public int UnauthorizedErrors { get; set; }
        public int OtherErrors { get; set; }

        public PartitionProcessingResult()
        {
            UnauthorizedErrors = 0;
            OtherErrors = 0;
            NumberOfReturnedResults = 0;
        }
    }
}