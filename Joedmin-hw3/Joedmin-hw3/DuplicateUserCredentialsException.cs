using System;

namespace Joedmin_hw3
{
    public class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException(string message) : base(message)
        { 
        }
    }
}
