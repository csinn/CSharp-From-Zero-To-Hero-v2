using System;
using System.Runtime.Serialization;

namespace Chapter1_Challenge3
{
    [Serializable]
    internal class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException(string username)
        {
            Console.WriteLine($"The user with username: {username}  is already in the database"); 
        }

    }
}