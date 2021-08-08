using System;

namespace Homework3
{
    public class UsersNotFoundException : Exception
    {
        public UsersNotFoundException(string reason) : base(reason)
        {
            Console.WriteLine(reason);
        }
    }

    public class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException(string reason) : base(reason)
        {
            Console.WriteLine(reason);
        }
    }
}