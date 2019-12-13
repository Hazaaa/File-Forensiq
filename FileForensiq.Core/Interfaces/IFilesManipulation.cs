using FileForensiq.Core.Models;

namespace FileForensiq.Core.Interfaces
{
    interface IFilesManipulation
    {
        PartitionProcessingResult GetFilesTree(string rootPath);
    }
}
