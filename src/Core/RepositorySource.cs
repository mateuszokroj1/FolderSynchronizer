using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using FolderSynchronizer.Models;

namespace FolderSynchronizer
{
    public class RepositorySource
    {
        public string Value { get; set; }

        public SourceType Type { get; set; }

        public static RepositorySource Parse(string value) =>
            !TryParse(value, out var result)
            ? throw new ArgumentException("Not recognized value.")
            : result;

        public static bool TryParse(string value, out RepositorySource result)
        {

        }
    }
}
