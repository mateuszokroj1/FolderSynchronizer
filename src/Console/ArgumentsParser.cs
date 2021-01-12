using FolderSynchronizer.Operations;

namespace FolderSynchronizer
{
    public static class ArgumentsParser
    {
        public static IOperation Parse(string[] args)
        {
            var parameters = ConcatStrings(" ", args).Trim().ToLowerInvariant();

            if (parameters == "init")
                return null;
            else if (parameters == "info")
                return null;
            else if (parameters == "pull")
                return null;
            else if (parameters == "push")
                return null;
            else
                return null;
        }

        private static string ConcatStrings(string separator, params string[] strings)
        {
            var output = string.Empty;

            var i = 0;
            foreach(var s in strings)
            {
                output += s;
                ++i;

                if (i < strings.Length - 1)
                    output += separator;
            }

            return output;
        }
    }
}
