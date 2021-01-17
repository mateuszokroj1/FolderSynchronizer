using System;
using System.Runtime.Serialization;

namespace FolderSynchronizer
{
    public class RepositoryExistsException : ApplicationException
    {
        public RepositoryExistsException() : base("Repository is exists in this directory.")
        {
        }

        public RepositoryExistsException(string message) : base(message)
        {
        }

        public RepositoryExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RepositoryExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
