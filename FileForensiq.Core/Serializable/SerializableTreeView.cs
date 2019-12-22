using FileForensiq.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace FileForensiq.Core.Serializable
{
    [Serializable]
    public class SerializableTreeView : ISerializable
    {
        private int numberOfFiles;
        private SerializableDirectoryNode rootNode;

        public SerializableTreeView(int numOfFiles)
        {
            numberOfFiles = numOfFiles;
        }

        #region Serialization

        protected SerializableTreeView(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            numberOfFiles = info.GetInt32("NumberOfFiles");
            rootNode = (SerializableDirectoryNode)info.GetValue("RootNode", typeof(SerializableDirectoryNode));
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("NumberOfFiles", numberOfFiles);
            info.AddValue("RootNode", rootNode);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            GetObjectData(info, context);
        }

        #endregion

        public void ConvertToSerializeData(PartitionProcessingResult toConvert)
        {
            if(toConvert == null)
            {
                return;
            }

            rootNode = SerializableDirectoryNode.ConvertToSerializableNode(toConvert.RootNode);
        }

        public PartitionProcessingResult ConvertToTreeViewData()
        {
            PartitionProcessingResult result = new PartitionProcessingResult();

            result.NumberOfReturnedResults = numberOfFiles;
            result.RootNode = SerializableDirectoryNode.ConvertToTreeNode(rootNode);

            return result;
        }
    }
}
