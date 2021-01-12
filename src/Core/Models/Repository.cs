using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FolderSynchronizer.Models
{
    public class Repository
    {
        #region Constructor

        public Repository(string path)
        {

        }

        protected Repository() { }

        #endregion


        #region Properties

        public RepositorySource Source { get; set; }

        public List<FileInfo> Files { get; } = new List<FileInfo>();

        public IEnumerable<Regex> Ignores { get; set; }

        public FileStream JsonFile { get; private set; }

        #endregion

        #region Methods

        public static Repository InitNew(string filePath)
        {
            var repository = new Repository();
            repository.Source = null;
            repository.Ignores = Enumerable.Empty<Regex>();
            

        }

        public void Update()
        {

        }

        #endregion
    }
}
