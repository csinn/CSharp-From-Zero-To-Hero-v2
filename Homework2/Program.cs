using System;

namespace Homework2
{
    public class Program
    {
        private const string password = "SecretPassw0rd";
        private const string username = "SecretUsEr";

        public static void Main(string[] args)
        {
            bool loginSucceeded = false;
            do
            {
                Console.WriteLine("Please enter your username:");
                var user = Console.ReadLine();
                Console.WriteLine("Please enter your password:");
                var pw = Console.ReadLine();

                loginSucceeded =
                    string.Equals(user, username, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(pw, password, StringComparison.Ordinal);
            } while (!loginSucceeded);

            Console.WriteLine("Logged in!");
        }
    }
}