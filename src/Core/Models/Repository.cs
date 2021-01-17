using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderSynchronizer.Models
{
    public class Repository : IDisposable
    {
        #region Constructor

        public Repository(string path)
        {

        }

        protected Repository() { }

        #endregion

        #region Properties

        public RepositorySource Source { get; private set; }

        public List<FileInfo> Files { get; private set; }

        public IEnumerable<Regex> Ignores { get; private set; }

        public FileStream JsonFile { get; private set; }

        public string RootDirectoryPath => Path.GetDirectoryName(JsonFile?.Name);

        #endregion

        #region Methods

        public async static Task<Repository> InitNewAsync(string filePath)
        {
            var repository = new Repository();
            repository.Source = null;
            repository.Ignores = Enumerable.Empty<Regex>();

            if (File.Exists(filePath))
                throw new RepositoryExistsException();

            if (Path.GetFileName(filePath).ToLowerInvariant() != ".synchronizer")
                throw new ArgumentException("Bad file path.");

            var dirPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(dirPath))
                throw new DirectoryNotFoundException();

            var initJson = new JsonFile
            {
                Files = new List<FileInfo>(),
                Ignores = Array.Empty<Regex>(),
                Source = null
            };

            var file = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);

            file.SetLength(0);

            using var writer = new StreamWriter(file);
            await writer.WriteAsync(JsonSerializer.Serialize(initJson));
            await writer.FlushAsync();

            repository.JsonFile = file;

            return repository;
        }

        

        internal async void Update()
        {
            JsonFile.SetLength(0);
            using var writer = new StreamWriter(JsonFile);

            await writer.WriteAsync(JsonSerializer.Serialize(new JsonFile
            {
                Source = Source,
                Files = Files,
                Ignores = Ignores
            }));
            await writer.FlushAsync();
        }

        public void GetChanges()
        {
            if (Source?.Value == null)
                throw new InvalidOperationException("No source.");


        }

        public void SendChanges()
        {
            if (Source?.Value == null)
                throw new InvalidOperationException("No source.");

            if (!(Source?.CanSendChanges ?? false))
                throw new InvalidOperationException("Sending changes is locked.");

            if (Source?.Type != SourceType.Path)
                throw new InvalidOperationException("Only local repository can be saved.");


        }

        public void Dispose()
        {
            JsonFile?.Close();
        }

        #endregion
    }
}
