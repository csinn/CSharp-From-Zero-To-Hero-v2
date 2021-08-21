using System;
using System.Collections.Generic;

namespace LINQ_Collections
{
    public class Login
    {
        private readonly Dictionary<string, string> _credentials;
        
        public Login()
        {
            _credentials = new Dictionary<string, string>()
            {
                { "admin", "aDmin" },
                { "guest", "guest" }
            };
        }

        public void LoginSequence()
        {
            Console.WriteLine("Welcome! Please enter username/password to logon:");

            string username = GetValidKeyboardInput("Enter username: ");

            string password = GetValidKeyboardInput("Enter password: ");

            ValidateCredentials(username, password);
        }

        private void ValidateCredentials(string username, string password)
        {
            if(_credentials.TryGetValue(username.ToLower(), out string storedPassword))
            {
                if(password != storedPassword)
                {
                    Console.WriteLine("Wrong password.");
                }
                else
                {
                    Console.WriteLine("Logged in!");
                }
            }
            else
            {
                Console.WriteLine("No such user exists.");
            }
        }

        public string GetValidKeyboardInput(string message)
        {
            string result;

            do
            {
                Console.Write(message);

                result = Console.ReadLine();

            } while (string.IsNullOrEmpty(result));

            return result;
        }
    }
}
