using System;
using System.Runtime.Serialization;

namespace Calculator.Exceptions
{
    [Serializable]
    internal class NotOpertorException : Exception
    {
        public NotOpertorException()
        {
        }

        public NotOpertorException(string message) : base(message)
        {
        }

        public NotOpertorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotOpertorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}