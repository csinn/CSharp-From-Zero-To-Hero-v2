using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BootCampV2.Homeworks.ThirdWeek.Exceptions
{
    class InvalidUserFileFormatException : Exception
    {
        public InvalidUserFileFormatException()
        {
        }

        public InvalidUserFileFormatException(string message) : base(message)
        {
        }

        public InvalidUserFileFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
