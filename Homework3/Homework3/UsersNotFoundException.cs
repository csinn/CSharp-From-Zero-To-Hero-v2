using System;

class UsersNotFoundException : Exception
{
    public UsersNotFoundException()
    {
    }

    public UsersNotFoundException(string message) : base(message)
    {
    }

    public UsersNotFoundException(string message, Exception inner) 
        : base(message, inner)
    {
    }
}