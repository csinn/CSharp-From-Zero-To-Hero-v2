using System;
using System.Runtime.Serialization;

namespace ElectricBillApi.Exceptions
{
    [Serializable]
    internal class NoProviderFoundException : Exception
    {
        public NoProviderFoundException()
        {
        }

        public NoProviderFoundException(string message) : base(message)
        {
        }

        public NoProviderFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoProviderFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}