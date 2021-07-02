using System;
using System.Runtime.Serialization;

namespace ElectricBillApi.Exceptions
{
    [Serializable]
    internal class NoSubscribedPowerPlantException : Exception
    {
        public NoSubscribedPowerPlantException()
        {
        }

        public NoSubscribedPowerPlantException(string message) : base(message)
        {
        }

        public NoSubscribedPowerPlantException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoSubscribedPowerPlantException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}