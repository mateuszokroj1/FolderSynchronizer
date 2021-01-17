using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace FolderSynchronizer
{
    public class RepositorySource
    {
        public string Value { get; set; }

        public SourceType Type { get; set; }

        public bool CanSendChanges { get; set; }

        public static RepositorySource Parse(string value) =>
            !TryParse(value, out var result)
            ? throw new ArgumentException("Not recognized value.")
            : result;

        public static bool TryParse(string value, out RepositorySource result)
        {
            if(new Regex(@"^[A-z]\:\\").IsMatch(value))
            {
                if (Directory.Exists(value) && File.Exists(Path.Combine(value, ".synchronizer")) || File.Exists(value))
                {
                    result = null;
                    return false;
                }

                result = new RepositorySource { Type = SourceType.Path, Value = value };
                return true;
            }
            else if(new Regex(@"^http(s)?\:\/\/").IsMatch(value))
            {
                if(Uri.TryCreate(value, UriKind.Absolute, out var uri))
                {
                    using var http = new HttpClient();

                    try
                    {
                        var response = http.GetAsync(uri).Result;

                        if(response.StatusCode != System.Net.HttpStatusCode.OK)
                        {
                            result = null;
                            return false;
                        }

                        var type = response.Content.Headers.ContentType.MediaType;
                        if (type is "text/plain" or "text/json" or "application/json")
                        {
                            result = new RepositorySource { Type = SourceType.Url, Value = value };
                            return true;
                        }

                    }
                    catch(Exception exc) when(exc is InvalidOperationException or HttpRequestException)
                    {
                        result = null;
                        return false;
                    }
                }
            }

            result = null;
            return false;
        }
    }
}
