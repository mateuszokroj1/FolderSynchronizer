using System;
using System.Security.Cryptography;

namespace FolderSynchronizer.Models
{
    public class FileInfo
    {
        public MD5 Checksum { get; set; }

        public string RelativePath { get; set; }

        public DateTime ModificationTime { get; set; }
    }
}
