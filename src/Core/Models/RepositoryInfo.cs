using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FolderSynchronizer.Models
{
    public class RepositoryInfo
    {
        public RepositorySource Source { get; set; }

        public List<FileInfo> Files { get; set; }

        public IEnumerable<Regex> Ignores { get; set; }
    }
}
