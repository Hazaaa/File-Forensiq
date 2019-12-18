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
        }

        /// <summary>
        /// Directory size in MB.
        /// </summary>
        public long Size { get; set; }
    }
}
