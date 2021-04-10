using System;
using System.IO;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
        }

        /// <summary>
        /// Shows a menu of commands.
        /// </summary>
        static void ShowMenu()
        {
            string filePath = @"Users.txt";
            string command;

            while(true)
            {
                Console.WriteLine($"[ Type a Command: ]");
                Console.WriteLine("      Login      ");
                Console.WriteLine("      Register      ");
                Console.WriteLine($"      Exit      ");

                command = PromptUserForInput($"command");

                if (command.Equals("login", StringComparison.OrdinalIgnoreCase))
                {
                    LoginUser(filePath);
                }

                if (command.Equals("register", StringComparison.OrdinalIgnoreCase))
                {
                    RegisterUser(filePath);
                }

                if (command.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Logs the user in.
        /// </summary>
        /// <param name="filePath">The file of login credentials.</param>
        static void LoginUser(string filePath)
        {
            string userName = PromptUserForInput("user name");
            string password = PromptUserForInput("password");

            if (CheckIfCredentialsAreValid(filePath, userName, password))
            {
                Console.WriteLine("Hello!");
            }
            else
            {
                Console.WriteLine($"Invalid credentials.");
            }
        }

        /// <summary>
        /// Prompts the user for input.
        /// </summary>
        /// <param name="inputType">The type of data being prompted for.</param>
        static string PromptUserForInput(string inputType)
        {
            Console.Write($"Enter a {inputType}: ");
            string input = Console.ReadLine();

            return input;
        }

        /// <summary>
        /// Checks the specified file to see if the credentials are valid.
        /// </summary>
        /// <param name="filePath">The file being checked against.</param>
        /// <param name="userName">The user name being checked.</param>
        /// <param name="password">The password being checked.</param>
        /// <returns>
        /// True if the user name and password match, false if it does not match.
        /// </returns>
        static bool CheckIfCredentialsAreValid(string filePath, string userName, string password)
        {
            StreamReader reader = new StreamReader(filePath);

            bool isDuplicate = false;

            while (reader.Peek() >= 0)
            {
                string line = reader.ReadLine();
                string[] words = line.Split(",");

                isDuplicate = words[0].Equals(userName) && words[1].Equals(password);
            }

            reader.Close();

            return isDuplicate;
        }

        /// <summary>
        /// Registers a new user and adds their user name and password 
        /// to the specified file. If the user is a duplicate, try again.
        /// </summary>
        /// <param name="filePath">The path of the file being written to.</param>
        static void RegisterUser(string filePath)
        {
            string userName;
            string password;

            do
            {
                userName = PromptUserForInput("user name");
                password = PromptUserForInput("password");

                try
                {
                    CheckIfDuplicate(filePath, userName);
                }
                catch (Exception)
                {
                    Console.WriteLine("User already exists.");
                }
            } 
            while (CheckIfDuplicate(filePath, userName));

            WriteToDataFile(filePath, userName, password);
        }

        /// <summary>
        /// Checks the specified file to see 
        /// if the specified user name is a duplicate.
        /// </summary>
        /// <param name="filePath">The file being checked against.</param>
        /// <param name="userName">The user name being checked.</param>
        /// <returns>
        /// True if the user name is a duplicate, false if it is not.
        /// </returns>
        static bool CheckIfDuplicate(string filePath, string userName)
        {
            StreamReader reader = new StreamReader(filePath);

            bool isDuplicate = false;

            while (reader.Peek() >= 0)
            {
                if (reader.ReadLine().Contains(userName))
                {
                    throw new Exception();
                }
            }

            reader.Close();

            return isDuplicate;
        }

        /// <summary>
        /// Writes the specified user name and password to the specified file.
        /// </summary>
        /// <param name="filePath">The path of the file being written to.</param>
        /// <param name="userName">The user name to be added.</param>
        /// <param name="password">The password to be added.</param>
        static void WriteToDataFile(string filePath, string userName, string password)
        {
            StreamWriter writer = new StreamWriter(filePath, append: true);

            string newEntry = $"{userName},{password}";
            writer.WriteLine(newEntry);

            writer.Close();
        }
    }
}
