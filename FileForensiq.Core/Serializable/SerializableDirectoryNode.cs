using FileForensiq.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileForensiq.Core.Serializable
{
    [Serializable]
    public class SerializableDirectoryNode : SerializableTreeNode
    {
        private DirectoryInfo directoryInfo;
        private int numberOfFiles;
        private List<SerializableTreeNode> childNodes;
        private long size;

        public SerializableDirectoryNode(string directoryName, DirectoryInfo info, int numOfFiles, long directorySize) : base(directoryName)
        {
            directoryInfo = info;
            numberOfFiles = numOfFiles;
            size = directorySize;
            childNodes = new List<SerializableTreeNode>();
            IconName = "folder.png";
        }

        #region Serialization

        protected SerializableDirectoryNode(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            directoryInfo = (DirectoryInfo)info.GetValue("DirectoryInfo", typeof(DirectoryInfo));
            numberOfFiles = info.GetInt32("NumberOfFiles");
            size = (long)info.GetValue("Size", typeof(long));
            childNodes = info.GetValue("ChildNodes", typeof(List<SerializableTreeNode>)) as List<SerializableTreeNode>;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("DirectoryInfo", directoryInfo);
            info.AddValue("NumberOfFiles", numberOfFiles);
            info.AddValue("Size", size);
            info.AddValue("ChildNodes", childNodes);
        }

        #endregion

        /// <summary>
        /// Converts from TreeNode to SerializableNode so it can be serialized in JSON.
        /// </summary>
        /// <param name="treeNode">Root node.</param>
        /// <returns>Root node object SerializableDirectoryNode type.</returns>
        public static SerializableDirectoryNode ConvertToSerializableNode(TreeNode treeNode)
        {
            var rootNode = treeNode as DirectoryTreeNode;

            SerializableDirectoryNode result = new SerializableDirectoryNode(rootNode.Text, rootNode.Tag as DirectoryInfo, rootNode.NumberOfFiles, rootNode.Size);

            foreach (var node in rootNode.Nodes.Cast<TreeNode>())
            {
                if(node is DirectoryTreeNode)
                {
                    result.childNodes.Add(ConvertToSerializableNode(node));
                }
                else
                {
                    result.childNodes.Add(SerializableFileNode.ConvertToSerializableNode(node));
                }
            }

            return result;
        }

        /// <summary>
        /// Converts from SerializabeTreeNode to TreeNode object so it can be used in TreeView control.
        /// </summary>
        /// <param name="node">Node for convert.</param>
        /// <returns>DirectoryTreeNode object.</returns>
        public static DirectoryTreeNode ConvertToTreeNode(SerializableTreeNode node)
        {
            var rootNode = node as SerializableDirectoryNode;

            DirectoryTreeNode result = new DirectoryTreeNode(rootNode.Name)
            {
                Tag = rootNode.directoryInfo,
                Size = rootNode.size,
                NumberOfFiles = rootNode.numberOfFiles,
                SelectedImageKey = rootNode.IconName,
                ImageKey = rootNode.IconName
            };

            foreach (var child in rootNode.childNodes)
            {
                if(child is SerializableDirectoryNode)
                {
                    result.Nodes.Add(ConvertToTreeNode(child));
                }
                else
                {
                    result.Nodes.Add(SerializableFileNode.ConvertToTreeNode(child));
                }
            }

            return result;
        }
    }
}
