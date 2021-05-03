using System;
using System.Collections.Generic;
using System.Data;
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
            var path = @"./Data/Users.txt";
            string choice = "0";

            CheckDuplicateUsers(path);

            while (!choice.Equals("Exit", StringComparison.OrdinalIgnoreCase))
            {
                choice = GetUserChoice();
                if (choice.Equals("Login", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        Login(path);
                    }
                    catch (FileNotFoundException exception)
                    {
                        throw new UsersNotFoundException(exception.FileName);
                    }
                    finally
                    {
                        Console.WriteLine();
                    }
                }
                else if (choice.Equals("Register", StringComparison.OrdinalIgnoreCase))
                {
                    Register(path);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid choice: {0}", choice);
                    Console.WriteLine();
                }
            }

        }

        static string GetUserChoice()
        {
            Console.WriteLine("Would you like to:");
            Console.WriteLine("Login");
            Console.WriteLine("Register");
            Console.WriteLine("Exit");
            Console.Write("Your Choice: ");
            var choice = Console.ReadLine();

            return choice;
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

        static void Login(string path)
        {
            var userData = GetUserData();
            var userLoginString = $"{userData[0]} - {userData[1]}";

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

            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var userNameCheck = line.Split(' ');
                    if (userNameCheck[0].Equals(userData[0]))
                    {
                        Console.WriteLine("User Name: {0} already exists", userData[0]);
                        return;
                    }
                }
            }

            using var sw = new StreamWriter(path, true);
            sw.Write(userRegisterString + Environment.NewLine);

            // added these line so that the userRegisterString gets appended to the Users.txt present
            // in the project folder as the during runtime it was only getting appended
            // to the bin/dotnetcoreapp/debug/Users.txt file

            using var sw1 = new StreamWriter(@"../../../Data/Users.txt", true);
            sw1.Write(userRegisterString + Environment.NewLine);
        }

        static void CheckDuplicateUsers(string path)
        {
            using var sr = new StreamReader(path);
            string line;

            line = sr.ReadToEnd();

            var entriesArray = line.Split(Environment.NewLine);
            var entriesSet = new HashSet<string>(entriesArray);

            if (entriesSet.Count != entriesArray.Length)
            {
                throw new DuplicateUserCredentialsException();
            }
        }
    }
}
