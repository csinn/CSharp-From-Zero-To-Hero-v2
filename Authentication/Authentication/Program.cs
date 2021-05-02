using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Authentication
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"./Users.txt";
            var choice = "0";

            while (!choice.Equals("Exit", StringComparison.OrdinalIgnoreCase))
            {
                choice = GetUserChoice();
                if (choice.Equals("Login", StringComparison.OrdinalIgnoreCase))
                {
                    Login(path);
                }
                else if (choice.Equals("Register",StringComparison.OrdinalIgnoreCase))
                {
                    Register(path);
                }

            }


        }

        static string[] GetUserData()
        {
            var userData = new string[2];
            Console.Write("Enter Your Username: ");
            userData[0] = Console.ReadLine();

            Console.Write("Enter Your Password: ");
            userData[1] = Console.ReadLine();

            return userData;
        }

        static string GetUserChoice()
        {
            Console.WriteLine("Would you like to:");
            Console.WriteLine("Login");
            Console.WriteLine("Register");
            Console.WriteLine("Exit");

            var choice = Console.ReadLine();

            return choice;
        }

        static void Login(string path)
        {
            var userData = GetUserData();
            var userLoginString = $"{userData[0]} - {userData[1]}";

            //if (path.Equals("./Users.txt"))
            //{
            //    throw new UsersNotFoundException("Users.txt does not exist");
            //}

            using var sr = new StreamReader(path);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                if (line.Equals(userLoginString))
                {
                    Console.WriteLine("Hello!");
                }
            }
        }

        static void Register(string path)
        {
            var userData = GetUserData();
            var userRegisterString = $"{userData[0]} - {userData[1]}";

            using var sw = new StreamWriter(path, true);
            sw.WriteLine(Environment.NewLine + userRegisterString);
            
            // added these line so that the userRegisterString gets appended to the Users.txt present
            // in the project folder as the during runtime it was only getting appended
            // to the bin/dotnetcoreapp/debug/Users.txt file

            using var sw1 = new StreamWriter(@"../../../Users.txt", true);
            sw1.WriteLine(Environment.NewLine + userRegisterString);
        }
    }
}
