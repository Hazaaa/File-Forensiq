using System.Collections.Generic;

namespace FileForensiq.Core.Models
{
    public class FilesProcessingResult
    {
        public List<string> FilesNames { get; set; }
        public int UnauthorizedErrors { get; set; }
        public int OtherErrors { get; set; }

        public FilesProcessingResult()
        {
            UnauthorizedErrors = 0;
            OtherErrors = 0;
            FilesNames = new List<string>();
        }
    }
}
