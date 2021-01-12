using System;
using System.IO;

using static System.Console;

namespace FolderSynchronizer.Operations
{
    internal class InitOperation : IOperation
    {
        public void Run()
        {
            var path = Environment.CurrentDirectory;

            if(File.Exists(Path.Combine(path, ".synchronizer")))
            {
                Error.Write("Repository exists in this directory.");
                return;
            }

            
        }
    }
}
