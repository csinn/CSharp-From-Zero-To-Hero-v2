using System;
using System.Runtime.Serialization;

namespace Chapter1_Challenge3
{
    [Serializable]
    internal class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException()
        {
            Console.WriteLine("The user is already in the database"); 
        }

    }
}