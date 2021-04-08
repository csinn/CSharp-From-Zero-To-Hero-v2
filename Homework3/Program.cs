using System;
using System.Collections.Generic;
using System.IO;

namespace Homework3
{
    class Program
    {
        static string path = "Users.txt";
        static void Main(string[] args)
        {
            WelcomeScreen(); 
        }

        static void WelcomeScreen()
        {
            Console.WriteLine("--- Options ---");
            Console.WriteLine("1-Login\n2-Register\n3-Exit");
            int number = 0;
            string input;
            bool option = false;
            while (!option)
            {
                Console.Write("Enter your choice:");
                input = Console.ReadLine();
                option = int.TryParse(input, out number);
                if (number < 1 || number > 3)
                {
                    Console.WriteLine("Choice must be 1, 2 or 3");
                    option = false;
                }
            }

            switch (number)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Register();
                    break;
                case 3:
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
            }

        }

        static void Register()
        {
            string username, password;
            IDictionary<string, string> users = new Dictionary<string, string>();
            try
            {
                users = GetUsersInfo(path);
            }
            catch (UsersNotFoundException ex)
            {

                Console.WriteLine(ex.Message + ", creating a new one");
            }

            do
            {
                Console.Write("Add a username:");
                username = Console.ReadLine().ToLower();

            } while (users.ContainsKey(username) || username.Contains(" "));

            Console.Write("Add a password:");
            password = Console.ReadLine();

            StreamWriter writer = new StreamWriter(path, append:true);
            writer.Write(username.ToLower() + " ");
            writer.WriteLine(password);
            writer.Close();
        }

        static IDictionary<string, string> GetUsersInfo(string path)
        {
            IDictionary<string, string> users = new Dictionary<string, string>();
            StreamReader reader;
            string[] line;
            try
            {
                reader = new StreamReader(path);
            }
            catch
            {
               throw new UsersNotFoundException($"{path} is not found");
            }

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine().Split(" ");
                users.Add(line[0], line[1]);
            }
            reader.Close();
            return users;
        }

        static void Login()
        {
            string username, password;
            IDictionary<string, string> users = new Dictionary<string, string>();
            try
            {
                users = GetUsersInfo(path);
            }
            catch (UsersNotFoundException ex)
            {

                Console.WriteLine(ex.Message);
            }

            if (users.Count > 0)
            {
                bool stopLoop = false;
                while (!stopLoop)
                {
                    Console.Write("Enter username:");
                    username = Console.ReadLine().ToLower();
                    Console.Write("Enter password:");
                    password = Console.ReadLine();

                    if (users.ContainsKey(username) && users[username] == password)
                    {
                        Console.WriteLine($"Hello {username}!");
                        stopLoop = true;
                    }
                    else
                    {
                        Console.WriteLine("Unsuccessful login");
                        Console.Write("Press a key to try again or 1 to go back main menu:");
                        var input = Console.ReadLine();
                        int result;
                        int.TryParse(input, out result);
                        if (result == 1)
                        {
                            WelcomeScreen();
                            return;
                        }
                    }
                }
            }
        }
    }

    class UsersNotFoundException : Exception
    {
        public UsersNotFoundException()
        {

        }

        public UsersNotFoundException(string msg) : base(msg)
        {

        }
    }
}
