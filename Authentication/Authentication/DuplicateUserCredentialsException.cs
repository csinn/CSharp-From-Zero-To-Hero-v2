using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication
{
    class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException(string userName) : base(userName)
        {
            Console.WriteLine(userName + " user already exists");
        }
    }
}
