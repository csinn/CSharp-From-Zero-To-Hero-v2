using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication
{
    class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException()
        {
            Console.WriteLine("There are duplicate entries in the file");
        }
    }
}
