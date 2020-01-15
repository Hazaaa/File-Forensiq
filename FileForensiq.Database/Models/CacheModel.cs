using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileForensiq.Database.Models
{
    public class CacheModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public long Size { get; set; }

        /// <summary>
        /// Number of files for directory, but for files this property is 0 or null.
        /// </summary>
        public int? NumberOfFiles { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastAccessTime { get; set; }

        public DateTime LastModificationTime { get; set; }
    }
}
