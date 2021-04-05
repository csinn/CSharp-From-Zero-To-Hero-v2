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
                    try
                    {
                        using (var stream = new StreamReader("Users.txt"))
                        {
                            Dictionary<string, string> usersAndPasswords = GetUsersAndPasswords("Users.txt");

                            while (true)
                            {
                                string[] credentials = GetCredencials();

                                if (usersAndPasswords.ContainsKey(credentials[0]))
                                {
                                    if (!(string.Equals(credentials[1], usersAndPasswords[credentials[0]])))
                                        Console.WriteLine("Invalid password. Please try again");
                                    else
                                    {
                                        Console.WriteLine("Hello!");
                                        break;
                                    }
                                }
                                else
                                    Console.WriteLine("Username is not registered");
                            }
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        throw new UsersNotFoundException("File Users.txt was not found. Make sure it is in the same directory as the .exe file.");
                    }
                }

                // Register
                else if (String.Equals(answer, "register", StringComparison.OrdinalIgnoreCase))
                {
                    Dictionary<string, string> usersAndPasswords = GetUsersAndPasswords("Users.txt");
                    try
                    {
                        using (var stream = new StreamWriter("Users.txt", true))
                        {
                            while (true)
                            {
                                try
                                {
                                    string[] credentials = GetCredencials();

                                    SaveToDictionary(usersAndPasswords, credentials);
                                    stream.WriteLine($"{credentials[0]} {credentials[1]}");
                                    Console.WriteLine("Hello!");
                                    break;
                                }
                                catch (DuplicateUserCredentialsException ex)
                                {
                                    Console.WriteLine($"{ex.Message}\nPlease try again.");
                                }
                            }
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        throw new UsersNotFoundException("File Users.txt was not found. Make sure it is in the same directory as the .exe file.");
                    }
                }
            }
            catch (UsersNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey(true);
        }

        // Get user's user name and password
        static string[] GetCredencials()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            return new string[] { username.Replace(" ", String.Empty), password.Replace(" ", String.Empty) };
        }

        // Reading users.txt and saving it's whole content to a dictionary
        static Dictionary<string, string> GetUsersAndPasswords(string path)
        {
            try
            {
                using (var stream = new StreamReader(path))
                {
                    string[] usersAndPasswords = stream.ReadToEnd().Split(Environment.NewLine);

                    Dictionary<string, string> usersInfos = new Dictionary<string, string>();

                    foreach (var item in usersAndPasswords)
                    {
                        string[] line = item.Split(' ');
                        SaveToDictionary(usersInfos, line);
                    }
                    return usersInfos;
                }
            }
            catch (FileNotFoundException)
            {
                throw new UsersNotFoundException("File Users.txt was not found. Make sure it is in the same directory as the .exe file.");
            }

        }

        // Adding user's data from 1 line of a file to a dictionary with check of duplicated user names (keys)
        static void SaveToDictionary(Dictionary<string, string> usersInfos, string[] line)
        {
            foreach (var item in line)
            {
                if (String.IsNullOrEmpty(item) || String.IsNullOrWhiteSpace(item))
                    return;
            }

            if (!(usersInfos.ContainsKey(line[0])))
            {
                usersInfos[line[0]] = line[1];
            }
            else
            {
                throw new DuplicateUserCredentialsException($"Users.txt contains duplicate user names! - ({line[0]})");
            }
        }
    }
}
