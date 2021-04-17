using HW3.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace HW3
{
    internal class Program
    {
        private const string usersFile = "Users.txt";

        private static bool ConsoleLogin()
        {
            try
            {
                string username = ConsoleReadLineWithTextPrompt("Username:\t");

                string password = ConsoleReadLineWithTextPrompt("Password:\t");

                return VerifyCredentials(username, password);
            }
            catch (UsersNotFoundException ex)
            {
                Console.WriteLine($"Couldn't load user credentials. Please contact @Kaisinel: {ex.Message}");
                return false;
            }
        }

        private static string ConsoleReadLineWithTextPrompt(string promptText)
        {
            Console.Write(promptText);
            string username = Console.ReadLine();
            return username;
        }

        private static void ConsoleRegisterAccount()
        {
            Dictionary<string, string> users;
            try
            {
                users = IO.Read.UserCredentials(usersFile);
            }
            catch (UsersNotFoundException ex)
            {
                Console.WriteLine($"Couldn't load user credentials. Please contact @Kaisinel: {ex.Message}");
                return;
            }

            do
            {
                string username = ConsoleReadLineWithTextPrompt("Username:\t");

                string password = ConsoleReadLineWithTextPrompt("Password:\t");

                if (!users.ContainsKey(username))
                {
                    try
                    {
                        IO.Write.AppendCredentials(usersFile, username, password);
                        Console.WriteLine("Useraccount created! You may login now.");
                    }
                    catch (FileNotFoundException ex)
                    {
                        throw new UsersNotFoundException(ex);
                    }

                    return;
                }

                Console.WriteLine("Username already exists! Please try again.");
            } while (true);
        }

        private static void Main(string[] args)
        {
            bool loggedIn = false;

            Console.WriteLine("Hello!");

            do
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("[L]ogin - [R]egister - [E]xit");

                var keyPressed = Console.ReadKey(true).Key;

                switch (keyPressed)
                {
                    case ConsoleKey.L:
                        if (ConsoleLogin())
                        {
                            loggedIn = true;
                            Console.WriteLine("Hello!");
                        }
                        else
                        {
                            Console.WriteLine("Oh no. Something went wrong!");
                        }
                        break;

                    case ConsoleKey.R:
                        ConsoleRegisterAccount();
                        break;

                    case ConsoleKey.E:
                        return;

                    default:
                        Console.WriteLine($"{keyPressed} is not an option. Try again!");
                        break;
                };
            } while (!loggedIn);
        }

        private static bool VerifyCredentials(string username, string password)
        {
            var users = IO.Read.UserCredentials(usersFile);
            return users.ContainsKey(username) && users[username].Equals(password);
        }
    }
}