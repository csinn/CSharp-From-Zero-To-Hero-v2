using System;

namespace HW3.Exceptions
{
    internal class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException() : base("Error: Username is already taken!")
        {
        }
    }
}