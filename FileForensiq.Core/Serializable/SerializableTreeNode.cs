using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace FileForensiq.Core.Serializable
{
    /// <summary>
    /// Because it's not possible to serialize TreeNode objects from TreeView this class is used for.
    /// </summary>
    [Serializable]
    public class SerializableTreeNode : ISerializable
    {
        private string name;   
        public string Name { get { return name; } set { name = value; } }

        private string iconName;
        public string IconName { get { return iconName; } set { iconName = value; } }

        public SerializableTreeNode(string nodeName)
        {
            name = nodeName;
        }

        #region Serialization

        protected SerializableTreeNode(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            name = info.GetString("Name");
            iconName = info.GetString("IconName");
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", name);
            info.AddValue("IconName", iconName);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            GetObjectData(info, context);
        }

        #endregion
    }
}
