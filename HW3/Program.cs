using System;
using System.IO;

namespace HW3
{
    internal class Program
    {
        private const string usersFile = "Users.txt";

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            try
            {
                MenuLoop();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        private static bool Login()
        {
            Console.WriteLine("Login:");

            string username = ReadLineWithPrompt("Username:\t");

            string password = ReadLineWithPrompt("Password:\t");

            if (VerifyCredentials(username, password))
            {
                Console.WriteLine("Hello!");

                return true;
            }

            Console.WriteLine("Login failed!");

            return false;
        }

        private static void MenuLoop()
        {
            bool loggedIn = false;

            do
            {
                Console.WriteLine("Please select an option:");

                Console.WriteLine("[L]ogin - [R]egister - [E]xit");

                var keyPressed = Console.ReadKey(true).Key;

                switch (keyPressed)
                {
                    case ConsoleKey.L:
                        Login();
                        break;

                    case ConsoleKey.R:
                        RegisterAccount();
                        break;

                    case ConsoleKey.E:
                        return;

                    default:
                        Console.WriteLine($"{keyPressed} is not a valid option.");
                        break;
                };
            } while (!loggedIn);
        }

        private static string ReadLineWithPrompt(string promptText)
        {
            Console.Write(promptText);

            return Console.ReadLine();
        }

        private static void RegisterAccount()
        {
            var users = IO.Read.UserCredentials(usersFile);

            Console.WriteLine("Account registration:");

            do
            {
                string username = ReadLineWithPrompt("Username:\t");

                string password = ReadLineWithPrompt("Password:\t");

                if (!users.ContainsKey(username))
                {
                    IO.Write.AppendCredentials(usersFile, username, password);

                    Console.WriteLine("Useraccount created! You may login now.");

                    return;
                }

                Console.WriteLine("Username already exists! Please try again.");
            } while (true);
        }

        private static bool VerifyCredentials(string username, string password)
        {
            var users = IO.Read.UserCredentials(usersFile);

            return users.ContainsKey(username) && users[username].Equals(password);
        }
    }
}