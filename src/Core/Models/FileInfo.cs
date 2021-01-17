using System;

namespace FolderSynchronizer.Models
{
    public class FileInfo
    {
        public byte[] Checksum { get; set; }

        public string RelativePath { get; set; }

        public DateTime ModificationTime { get; set; }
    }
}
