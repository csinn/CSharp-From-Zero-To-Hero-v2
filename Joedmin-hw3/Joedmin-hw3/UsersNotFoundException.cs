using System;
        
namespace Joedmin_hw3
{
    public class UsersNotFoundException : Exception
    {
        public UsersNotFoundException(string message) : base(message)
        { 
        
        }
    }
}
