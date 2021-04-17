using System.IO;

namespace HW3.Exceptions
{
    public class UsersNotFoundException : FileNotFoundException
    {
        public UsersNotFoundException(string? filename) : base("Users file not found!", filename)
        {
        }
    }
}