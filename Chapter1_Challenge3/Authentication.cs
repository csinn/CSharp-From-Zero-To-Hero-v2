using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Chapter1_Challenge3
{
    public static class Authentication
    {
        const string file = @"user.txt";

        public static string ReadFile()
        {
            String contents;
            try
            {
                using (var stream = new StreamReader(file))
                {
                    contents = stream.ReadToEnd();
                }
            }
            catch
            {
                throw new UsersNotFoundException();
            }

            return contents; 
        }

        

        public static void Login()
        {
            Console.Write("May I have your username: ");
            var username = Console.ReadLine();
            Console.Write("May I have your password: ");
            var password = Console.ReadLine(); 
                        
            var content = ReadFile();
            var contentLines = content.Split("/n");

            var userdata = new Dictionary<string, string>();

            foreach (var line in contentLines)
            {
                var user = line.Split(" ");
                userdata[user[0]] = user[1].Trim('\r', '\n');    
            }

            foreach (var user in userdata)
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

        public static void Register()
        {
            Console.Write("May I have your username: ");
            var username = Console.ReadLine();
            Console.Write("May I have your password: ");
            var password = Console.ReadLine();

            var content = ReadFile();
            var contentLines = content.Split("/n");

            var userdata = new Dictionary<string, string>();

            foreach (var line in contentLines)
            {
                var user = line.Split(" ");
                userdata[user[0]] = user[1].Trim('\r', '\n');
            }

            if (userdata.ContainsKey(username))
            {
                throw new DuplicateUserCredentialsException(); 
            }
            else
            {
                WriteData(content, username, password); 
 
            }

        }

        private static void WriteData(string content, string username, string password)
        {
            try
            {
                using (var stream = new StreamWriter(file, false))
                {
                    stream.Write($"{content}{Environment.NewLine}{username} {password}");
                }
            }
            catch
            {
                throw new UsersNotFoundException();
            }
           
        }

    }
    
}