using FileForensiq.Core.Models;

namespace FileForensiq.Core.Interfaces
{
    interface IFileSystemManipulation
    {
        ChildNodesResult GetDirectoryChildren(string directoryPath);
        long CalculateDirectorySize(DirectoryTreeNode rootNode);

        int CalculateNumberOfFiles(DirectoryTreeNode rootNode);
    }
}
