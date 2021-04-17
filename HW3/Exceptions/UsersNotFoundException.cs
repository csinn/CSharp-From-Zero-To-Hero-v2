using System;
using System.IO;

namespace HW3.Exceptions
{
    public class UsersNotFoundException : Exception
    {
        public UsersNotFoundException(FileNotFoundException inner) : base("'Users' file containing login credentials not found!", inner)
        {
        }
    }
}