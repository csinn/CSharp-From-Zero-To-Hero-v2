using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BootCampV2.Homeworks.ThirdWeek.Exceptions
{
    class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException()
        {
        }

        public DuplicateUserCredentialsException(string message) : base(message)
        {
        }

        public DuplicateUserCredentialsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
