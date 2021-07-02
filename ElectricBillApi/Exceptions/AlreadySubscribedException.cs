using System;
using System.Runtime.Serialization;

namespace ElectricBillApi.Exceptions
{
    [Serializable]
    internal class AlreadySubscribedException : Exception
    {
        public AlreadySubscribedException()
        {
        }

        public AlreadySubscribedException(string message) : base(message)
        {
        }

        public AlreadySubscribedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlreadySubscribedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}