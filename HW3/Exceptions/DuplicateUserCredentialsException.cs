using System;

namespace HW3.Exceptions
{
    public class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException() : base("Error: Username is already taken!")
        {
        }
    }
}