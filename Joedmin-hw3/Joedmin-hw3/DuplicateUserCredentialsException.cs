using System;

namespace Joedmin_hw3
{
    public class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException(string duplicatedUsername) : base($"The Users.txt contains duplicated users - {duplicatedUsername}!")
        { 
        }
    }
}
