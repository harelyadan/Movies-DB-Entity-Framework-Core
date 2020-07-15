using System;
using System.Runtime.Serialization;

namespace MoviesDB_Manager
{
    [Serializable]
    internal class ItemExistException : Exception
    {
        public ItemExistException()
        {
        }

        public ItemExistException(string message) : base(message)
        {
        }

        public ItemExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ItemExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}