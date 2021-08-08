using System;
using System.Collections.Generic;
using System.IO;

namespace Homework3
{
    internal class Program
    {
        private static int choise;
        private static readonly string UsersDataFile = @"Users.txt";

        private static void Main(string[] args)
        {
            printScreen();
        }

        private static void printScreen()
        {
            do
            {
                Console.WriteLine("==================================");
                Console.WriteLine("Welcome, please choose an option:");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit\n");

                int.TryParse(Console.ReadLine(), out choise);

                switch (choise)
                {
                    case 1:
                        login();
                        break;
                    case 2:
                        register();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Unrecognized choise");
                        break;
                }
            } while (choise != 3);
        }

        private static void login()
        {
            CheckLogin(GetUsername(), GetPassword());
        }

        private static void register()
        {
            CheckRegistration(GetUsername(), GetPassword());
        }

        #region input crendentials

        private static string GetUsername()
        {
            Console.Write("Username: ");
            return Console.ReadLine();
        }

        private static string GetPassword()
        {
            Console.Write("Password: ");
            return Console.ReadLine();
        }

        #endregion

        #region check credentials

        private static void CheckLogin(string username, string password)
        {
            var contents = ReadAllText();
            var accounts = contents.Split("\n");
            var UsersDictionary = new Dictionary<string, string>();

            foreach (var account in accounts)
            {
                var x = account.Split(" : ");
                UsersDictionary.Add(x[0], x[1]);
            }

            foreach (var user in UsersDictionary)
            {
                if (user.Key == username && user.Value == password)
                {
                    Console.WriteLine($"Login success, welcome back {username}");
                    return;
                }
            }
            // if doesnt return
            Console.WriteLine("Incorrect username or password");
        }

        private static void CheckRegistration(string username, string password)
        {
            try
            {
                var contents = ReadAllText();
                var accounts = contents.Split("\n");
                var UsersDictionary = new Dictionary<string, string>();

                foreach (var account in accounts)
                {
                    var x = account.Split(" : ");
                    UsersDictionary.Add(x[0], x[1]);
                }

                if (UsersDictionary.ContainsKey(username))
                {
                    throw new DuplicateUserCredentialsException("Username is already in use");
                }
                else
                {
                    WriteAllText($"{contents}\n{username} : {password}");
                    Console.WriteLine($"Registered successfully, welcome {username}");
                }            
            }
            catch (DuplicateUserCredentialsException ex)
            {
                printScreen();
            }
        }

        #endregion

        #region Read/Write File

        private static string ReadAllText()
        {
            try
            {
                using (var stream = new StreamReader(UsersDataFile))
                {
                    var contents = stream.ReadToEnd();
                    return contents;
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new UsersNotFoundException("Users.txt file not found");
            }
        }

        private static void WriteAllText(string data)
        {
            using (var stream = new StreamWriter(UsersDataFile))
            {
                stream.Write(data);
            }
        }

        #endregion
    }
}