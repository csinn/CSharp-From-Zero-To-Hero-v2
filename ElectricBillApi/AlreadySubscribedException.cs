using System;
using System.Runtime.Serialization;

namespace ElectricBillApi
{
    [Serializable]
    internal class AlreadySubscribedException : Exception
    {
        public AlreadySubscribedException()
        {
        }

        public AlreadySubscribedException(string message) : base(message)
        {
            Console.WriteLine("Plant " + message + " is already subscribed to.");
        }

        public AlreadySubscribedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlreadySubscribedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}