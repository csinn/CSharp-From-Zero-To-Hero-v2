using System;
using System.Runtime.Serialization;

namespace ElectricBillApi.Exceptions
{
    [Serializable]
    internal class NoValidPowerPlantException : Exception
    {
        public NoValidPowerPlantException()
        {
        }

        public NoValidPowerPlantException(string message) : base(message)
        {
        }

        public NoValidPowerPlantException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoValidPowerPlantException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}