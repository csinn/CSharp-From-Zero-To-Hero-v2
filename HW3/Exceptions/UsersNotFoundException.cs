using System.IO;

namespace HW3.Exceptions
{
    internal class UsersNotFoundException : FileNotFoundException
    {
        public UsersNotFoundException(string? message, string? filename) : base(message, filename)
        {
        }
    }
}