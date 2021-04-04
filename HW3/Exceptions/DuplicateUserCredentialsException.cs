using System;

namespace HW3.Exceptions
{
    internal class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException(string? message) : base(message)
        {
        }
    }
}