using System;
using System.Runtime.Serialization;

namespace ElectricBillApi.Exceptions
{
    [Serializable]
    internal class NoValidAdressException : Exception
    {
        public NoValidAdressException()
        {
        }

        public NoValidAdressException(string message) : base(message)
        {
        }

        public NoValidAdressException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoValidAdressException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}