using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileForensiq.Core.Models
{
    public class ChildNodesResult
    {
        public List<TreeNode> ChildNodes { get; set; }
        public Exception Error { get; set; }
        public long Size { get; set; }

        public ChildNodesResult()
        {
            ChildNodes = new List<TreeNode>();
            Size = 0;
        }
    }
}
