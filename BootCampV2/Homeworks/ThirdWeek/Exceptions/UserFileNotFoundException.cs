using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace BootCampV2.Homeworks.ThirdWeek.Exceptions
{
    public class UserFileNotFoundException : Exception
    {
        public UserFileNotFoundException()
        {
        }

        public UserFileNotFoundException(string message) : base(message)
        {
        }

        public UserFileNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
