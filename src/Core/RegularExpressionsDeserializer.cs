using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FolderSynchronizer
{
    public class RegularExpressionsDeserializer : IDeserialize<IEnumerable<Regex>>
    {
        public IEnumerable<Regex> Deserialize(Stream inputStream)
        {
            if (inputStream is null)
                throw new ArgumentNullException(nameof(inputStream));

            if (!inputStream.CanRead)
                throw new IOException("Cannot read stream.");

            if (inputStream.Length < 1)
                return Enumerable.Empty<Regex>();

            using var reader = new StreamReader(inputStream);

            var lines = new List<string>();

            var line = reader.ReadLine();
            while (line != null)
            {
                lines.Add(line);
                line = reader.ReadLine();
            }

            try
            {
                return lines.Select(value => new Regex(value));
            }
            catch(ArgumentException)
            {
                throw new FormatException("Unrecognized value in stream.");
            }
        }
    }
}
