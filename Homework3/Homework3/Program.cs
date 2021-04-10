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

            while(true)
            {
                Console.WriteLine($"Type a Command:{Environment.NewLine}" 
                                 + $"Login{Environment.NewLine}"
                                 + $"Register{Environment.NewLine}"
                                 + $"Exit{ Environment.NewLine}");

                string command = PromptUserForInput("command");

                if (command.Equals("login", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        LoginUser(filePath);
                    }
                    catch (UsersNotFoundException)
                    {
                        Console.WriteLine("Users.txt not found.");
                    }
                }

                if (command.Equals("register", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        RegisterUser(filePath);
                    }
                    catch (UsersNotFoundException)
                    {
                        Console.WriteLine("Users.txt not found.");
                    }
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
                Console.WriteLine("Invalid credentials.");
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
            StreamReader reader;

            try
            {
                reader = new StreamReader(filePath);
            }
            catch (FileNotFoundException)
            {
                throw new UsersNotFoundException();
            }

            bool isValid = false;

            while (reader.Peek() >= 0)
            {
                string line = reader.ReadLine();
                string[] words = line.Split(",");

                isValid = words[0].Equals(userName) && words[1].Equals(password);

                if (isValid)
                {
                    break;
                }
            }

            reader.Close();

            return isValid;
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
            bool isDuplicate;

            do
            {
                userName = PromptUserForInput("user name");
                password = PromptUserForInput("password");

                try
                {
                    isDuplicate = CheckIfDuplicate(filePath, userName); 
                }
                catch (DuplicateUserCredentialsException)
                {
                    isDuplicate = true;
                    Console.WriteLine($"User already exists.{Environment.NewLine}");
                }

                if (!isDuplicate)
                {
                    WriteToDataFile(filePath, userName, password);
                    break;
                }
            } 
            while (isDuplicate);
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
            StreamReader reader;

            try
            {
                reader = new StreamReader(filePath);
            }
            catch (FileNotFoundException)
            {
                throw new UsersNotFoundException();
            }

            bool isDuplicate = false;

            while (reader.Peek() >= 0)
            {
                string line = reader.ReadLine();
                string[] words = line.Split(",");

                isDuplicate = words[0].Equals(userName);

                if (isDuplicate)
                {
                    break;
                }
            }

            reader.Close();

            if (isDuplicate)
            {
                throw new DuplicateUserCredentialsException();
            }

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
