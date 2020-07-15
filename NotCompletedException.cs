using System;
using System.Runtime.Serialization;

namespace MoviesDB_Manager
{
    [Serializable]
    internal class NotCompletedException : Exception
    {
        public NotCompletedException()
        {
        }

        public NotCompletedException(string message) : base(message)
        {
        }

        public NotCompletedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotCompletedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}