using FileForensiq.Core.Models;

namespace FileForensiq.Core.Interfaces
{
    interface IFilesManipulation
    {
        FilesProcessingResult GetFilesNames(string rootPath);
    }
}
