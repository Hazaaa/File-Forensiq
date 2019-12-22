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
    public class SerializableFileNode : SerializableTreeNode
    {
        private FileInfo fileInfo;

        public SerializableFileNode(string fileName, FileInfo fileInfo, string iconName) : base(fileName)
        {
            this.fileInfo = fileInfo;
            this.IconName = iconName;
        }

        #region Serialization

        protected SerializableFileNode(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            fileInfo = (FileInfo)info.GetValue("FileInfo", typeof(FileInfo));
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("FileInfo", fileInfo);
        }

        #endregion

        /// <summary>
        /// Returns TreeNode as SerializableFileNode so it can easly be serialized in JSON.
        /// </summary>
        /// <param name="node">File node.</param>
        /// <returns>New SerializableFileNode object.</returns>
        public static SerializableFileNode ConvertToSerializableNode(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            return new SerializableFileNode(node.Text, node.Tag as FileInfo, node.ImageKey);
        }

        /// <summary>
        /// Returns TreeNode object that can be displayed in TreeView control.
        /// </summary>
        /// <param name="node">Node to convert.</param>
        /// <returns>TreeNode object.</returns>
        public static TreeNode ConvertToTreeNode(SerializableTreeNode node)
        {
            var fileNode = node as SerializableFileNode;

            if (fileNode == null)
            {
                return null;
            }

            return new TreeNode(fileNode.Name)
            {
                Tag = fileNode.fileInfo,
                ImageKey = fileNode.IconName,
                SelectedImageKey = fileNode.IconName
            };
        }
    }
}
