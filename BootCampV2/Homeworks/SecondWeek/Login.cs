using System;
using System.Collections.Generic;
using System.Text;

namespace BootCampV2.Homeworks.SecondWeek
{
    class Login
    {
        public string Username{ get; private set; }
        public string Password{ get; private set; }

        public void SetData(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public void TryLogin()
        {
            Console.WriteLine("Enter a valid username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter a valid password:");
            string password = Console.ReadLine();

            var validUsername = ValidateUsername(username);
            var validPassword = ValidatePassword(password);

            if(validUsername && validPassword)
                Console.WriteLine("Logged In");
            else
                Console.WriteLine("Wrong username or password");
        }

        public bool ValidateUsername(string username)
        {
            var adaptedUsername = Username.ToLower();
            var adaptedusername = username.ToLower();

            if (adaptedUsername.Equals(adaptedusername))
                return true;

            return false;
        }

        public bool ValidatePassword(string password)
        {
            if (Password.Equals(password))
                return true;

            return false;
        }
    }
}
