﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileForensiq.Database.Models
{
    public class CacheModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public long Size { get; set; }

        /// <summary>
        /// Number of files for directory, but for files this property is 0.
        /// </summary>
        public int NumberOfFiles { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastAccessTime { get; set; }

        public DateTime LastModificationTime { get; set; }

        [Browsable(false)]
        public string DateCached { get; set; }
    }
    public class CacheModelComaparer : IEqualityComparer<CacheModel>
    {
        public bool Equals(CacheModel x, CacheModel y)
        {
            // Two items are equal if their ids are equal.
            return x.Id == y.Id;
        }

        public int GetHashCode(CacheModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
