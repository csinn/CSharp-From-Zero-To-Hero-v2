using System;
        
namespace Joedmin_hw3
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message)
        { 
        
        }
    }
}
