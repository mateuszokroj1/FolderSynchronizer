using FolderSynchronizer;

using static System.Console;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Folder Synchronizer");
            WriteLine("Version 1.0");

            var operation = ArgumentsParser.Parse(args);

            if(operation == null)
            {
                Error.Write("Bad arguments. Try again.");
                return;
            }

            operation.Run();
        }
    }
}
