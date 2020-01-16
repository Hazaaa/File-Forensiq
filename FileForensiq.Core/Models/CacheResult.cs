using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileForensiq.Core.Models
{
    public class CacheResult
    {
        public long Size { get; set; }
        public int NumberOfFiles { get; set; }

        public CacheResult()
        {
            Size = 0;
            NumberOfFiles = 0;
        }
    }
}
