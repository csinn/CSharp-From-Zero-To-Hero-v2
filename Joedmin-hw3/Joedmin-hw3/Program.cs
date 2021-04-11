using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Joedmin_hw3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("What do you want to do? login/register/exit: ");
                string answer = Console.ReadLine();

                // Exit
                if (String.Equals(answer, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    Process.GetCurrentProcess().Kill();
                }

                // Login
                else if (String.Equals(answer, "login", StringComparison.OrdinalIgnoreCase))
                {
                    using (var stream = new StreamReader("Users.txt"))
                    {
                        Dictionary<string, string> usersAndPasswords = GetCredentials("Users.txt");

                        string[] credentials = GetCredencials();

                        if (usersAndPasswords.ContainsKey(credentials[0]))
                        {
                            if (!(string.Equals(credentials[1], usersAndPasswords[credentials[0]])))
                                Console.WriteLine("Invalid password.");
                            else
                            {
                                Console.WriteLine("Hello!");
                            }
                        }
                        else
                            Console.WriteLine("Username is not registered.");
                    }
                }

                // Register
                else if (String.Equals(answer, "register", StringComparison.OrdinalIgnoreCase))
                {
                    Dictionary<string, string> usersAndPasswords = GetCredentials("Users.txt");
                    using (var stream = new StreamWriter("Users.txt", true))
                    {
                        string[] credentials = GetCredencials();
                        SaveToDictionary(usersAndPasswords, credentials);
                        stream.WriteLine($"{credentials[0]} {credentials[1]}");
                        Console.WriteLine("Hello!");
                    }
                }
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DuplicateUserCredentialsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Users.txt was not found. Make sure it is in the same directory as the .exe file.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Get username and password
        /// </summary>
        /// <returns></returns>
        static string[] GetCredencials()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            return new string[] { username.Replace(" ", String.Empty), password.Replace(" ", String.Empty) };
        }

        /// <summary>
        /// Reading Users.txt and saving it's whole content to a dictionary
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static Dictionary<string, string> GetCredentials(string path)
        {
            using (var stream = new StreamReader(path))
            {
                string[] fileContent = stream.ReadToEnd().Split(Environment.NewLine);

                Dictionary<string, string> credentials = new Dictionary<string, string>();

                foreach (var item in fileContent)
                {
                    if (!String.IsNullOrEmpty(item) || !String.IsNullOrWhiteSpace(item))
                    {
                        string[] line = item.Split(' ');
                        SaveToDictionary(credentials, line);
                    }
                }
                return credentials;
            }
        }

        /// <summary>
        /// Adding user's data from 1 line of a file to a dictionary
        /// </summary>
        /// <param name="usersInfos"></param>
        /// <param name="userAndPassword"></param>
        static void SaveToDictionary(Dictionary<string, string> usersInfos, string[] userAndPassword)
        {
            if (!ValidateCredentials(userAndPassword))
                return;

            if (!(usersInfos.ContainsKey(userAndPassword[0])))
            {
                usersInfos[userAndPassword[0]] = userAndPassword[1];
            }
            else
            {
                throw new DuplicateUserCredentialsException(userAndPassword[0]);
            }
        }

        /// <summary>
        /// Checks if credentials aren't empty
        /// </summary>
        /// <param name="userAndPassword"></param>
        /// <returns></returns>
        static bool ValidateCredentials(string[] userAndPassword)
        {
            if (userAndPassword.Length != 2)
                return false;
            foreach (var item in userAndPassword)
            {
                if (String.IsNullOrEmpty(item) || String.IsNullOrWhiteSpace(item))
                    return false;
            }
            return true;
        }
    }
}
