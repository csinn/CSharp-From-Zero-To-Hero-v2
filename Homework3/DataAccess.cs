using System;
using System.Collections.Generic;
using System.IO;

namespace start
{
    public static class DataAccess
    {
        private static readonly string fileName = $"Users.txt";

        private static string GetStringsFromFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new UsersNotFoundException("File Users.txt does not exists.", ex);
            }
        }

        public static List<User> GetUsers()
        {
            List<User> validUsers = new List<User>();

            string[] validUserStringArray = GetStringsFromFile().Split(Environment.NewLine);

            foreach (var userInfo in validUserStringArray)
            {
                string[] userCred = userInfo.Split(",");

                User user = new User();
                user.Name = userCred[0];
                user.Password = userCred[1];

                validUsers.Add(user);
            }

            return validUsers;
        }

        public static void AddUserToFile(User user)
        {
            if (user != null)
            {
                string userString = $"{user.Name},{user.Password}";

                bool isNewLineLast = GetStringsFromFile().EndsWith(Environment.NewLine);

                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    if (isNewLineLast)
                    {
                        writer.Write(userString + Environment.NewLine);
                    }
                    else
                    {
                        writer.Write(Environment.NewLine + userString);
                    }
                }
            }
        }

        public static bool DoesUserExits(string applicantName)
        {
            List<User> validUsers = GetUsers();

            foreach (var user in validUsers)
            {
                if (user.Name == applicantName)
                {
                    return true;
                }
            }
            return false;
        }
    }
    internal class UsersNotFoundException : Exception
    {
        public UsersNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
            Console.WriteLine(message);
        }
    }
}