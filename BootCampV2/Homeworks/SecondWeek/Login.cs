using System;
using System.Collections.Generic;
using System.Text;

namespace BootCampV2.Homeworks.SecondWeek
{
    class Login
    {
        public string Username{ get; private set; }
        public string Password{ get; private set; }

        public Login (string username, string password)
	    {
            Username = username;
            Password = password;
	    }

        public void TryLogin()
        {
            Console.WriteLine("Enter a valid username:");
            string inputusername = Console.ReadLine();

            Console.WriteLine("Enter a valid password:");
            string inputpassword = Console.ReadLine();

            var validUsername = ValidateUsername(inputusername);
            var validPassword = ValidatePassword(inputpassword);

            if(validUsername && validPassword)
                Console.WriteLine("Logged In");
            else
                Console.WriteLine("Wrong username or password");
        }

        private bool ValidateUsername(string inputusername)
        {   
            return Username.Equals(inputusername, StringComparison.OrdinalIgnoreCase);
        }

        private bool ValidatePassword(string inputpassword)
        {
            if (Password.Equals(inputpassword))
                return true;

            return false;
        }
    }
}
