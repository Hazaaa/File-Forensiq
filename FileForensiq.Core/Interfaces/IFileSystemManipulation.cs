using FileForensiq.Core.Models;
using System.IO;

namespace FileForensiq.Core.Interfaces
{
    interface IFileSystemManipulation
    {
        ChildNodesResult GetDirectoryChildren(string directoryPath);
        long CalculateDirectorySize(DirectoryInfo directory);
        int CalculateNumberOfFiles(DirectoryInfo rootNode);
    }
}
