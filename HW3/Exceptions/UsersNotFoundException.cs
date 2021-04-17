using System.IO;

namespace HW3.Exceptions
{
    internal class UsersNotFoundException : FileNotFoundException
    {
        public UsersNotFoundException(string? filename) : base("Users file not found!", filename)
        {
        }
    }
}