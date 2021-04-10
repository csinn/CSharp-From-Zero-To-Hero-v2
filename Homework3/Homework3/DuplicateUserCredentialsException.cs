using System;

class DuplicateUserCredentialsException : Exception
{
    public DuplicateUserCredentialsException()
    {
    }

    public DuplicateUserCredentialsException(string message) : base(message)
    {
    }

    public DuplicateUserCredentialsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}