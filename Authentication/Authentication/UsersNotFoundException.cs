using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Authentication
{
    class UsersNotFoundException : FileNotFoundException
    {
        public UsersNotFoundException(string reason) : base(reason)
        {
            Console.WriteLine(reason + " was not found");
        }
    }
}
