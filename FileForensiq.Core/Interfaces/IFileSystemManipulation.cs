using FileForensiq.Core.Models;

namespace FileForensiq.Core.Interfaces
{
    interface IFileSystemManipulation
    {
        PartitionProcessingResult GetPartitionFileTree(string rootPath, bool includeFiles = false);
        long CalculateDirectorySize(DirectoryTreeNode rootNode);
    }
}
