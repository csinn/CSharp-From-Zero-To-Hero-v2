using System;
using System.Runtime.Serialization;

namespace Chapter1_Challenge3
{
    [Serializable]
    internal class UsersNotFoundException : Exception
    {
        public UsersNotFoundException()
        {
            Console.WriteLine("ERROR: There is no user.txt");
        }

        
    }
}