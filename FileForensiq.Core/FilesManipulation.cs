using FileForensiq.Core.Interfaces;
using FileForensiq.Core.Models;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;

namespace FileForensiq.Core
{
    public class FilesManipulation : IFilesManipulation
    {
        public FilesManipulation()
        {

        }

        /// <summary>
        /// Returns name of all files (including their paths) starting from Root path.
        /// </summary>
        /// <param name="rootPath">Root path from which processing starts.</param>
        /// <returns>FileProcessingResult object with all files full names and number of errors.</returns>
        public FilesProcessingResult GetFilesNames(string rootPath)
        {
            FilesProcessingResult result = new FilesProcessingResult();
            ConcurrentBag<string> filesNames = new ConcurrentBag<string>();

            ConcurrentQueue<string> pendingPaths = new ConcurrentQueue<string>();
            pendingPaths.Enqueue(rootPath);

            while (pendingPaths.Count > 0)
            {
                try
                {
                    pendingPaths.TryDequeue(out rootPath);

                    var files = Directory.GetFiles(rootPath);

                    Parallel.ForEach(files, x => filesNames.Add(x));

                    var directories = Directory.GetDirectories(rootPath);

                    Parallel.ForEach(directories, (x) => pendingPaths.Enqueue(x));
                }
                catch (UnauthorizedAccessException)
                {
                    result.UnauthorizedErrors++;
                    continue;
                }
                catch (Exception)
                {
                    result.OtherErrors++;
                    continue;
                }
            }

            result.FilesNames.AddRange(filesNames.ToArray());
            return result;
        }
    }
}
