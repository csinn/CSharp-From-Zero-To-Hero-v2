using System.IO;
using System;
using System.Linq;

namespace ThirdLessonHomework
{
    internal class Program
    {
        const string Login = "1";
        const string Register = "2";
        const string Exit = "3";
        const string Path = "Users.txt";

        static void Main(string[] args)
        {
            RunApp();
        }

        static void RunApp()
        {
            string usersDataInString = ReadUsersData(Path);
            string[] usersDataSplit = SplitUsersData(usersDataInString);
            string[] usernames = GetUsernamesFromSplitData(usersDataSplit);
            string[] passwords = GetPasswordsFromSplitData(usersDataSplit);

            string userAction = PromptUserChoice();
            ExecuteUserChosenAction(userAction, usernames, passwords);
        }

        static string ReadUsersData(string path)
        {
            StreamReader stream = new StreamReader(path);
            string contents = stream.ReadToEnd();
            stream.Dispose();

            return contents;
        }

        static string[] SplitUsersData(string usersData)
        {
            string[] splitData = usersData.Split(' ', '\n');
            return splitData;
        }

        static string[] GetUsernamesFromSplitData(string[] splitData)
        {
            string[] usernames = new string[splitData.Length / 2];

            for (int index = 0; index < splitData.Length; index++)
            {
                if (index % 2 == 0)
                {
                    usernames[index / 2] = splitData[index].Trim();
                }
            }

            return usernames;
        }

        static string[] GetPasswordsFromSplitData(string[] splitData)
        {
            string[] passwords = new string[splitData.Length / 2];

            for (int index = 0; index < splitData.Length; index++)
            {
                if (index % 2 != 0)
                {
                    passwords[index / 2] = splitData[index].Trim();
                }
            }

            return passwords;
        }

        static string PromptUserChoice()
        {
            Console.WriteLine("App has started!");
            Console.WriteLine("To login enter - 1. To register enter - 2. To exit the app enter - 3.");

            string userAction = Console.ReadLine();
            return userAction;
        }

        static void ExecuteUserChosenAction(string userAction, string[] usernames, string[] passwords)
        {
            bool userChoseWrongAction = string.IsNullOrEmpty(userAction) || 
                userAction != Login && 
                userAction != Register && 
                userAction != Exit;

            if (userChoseWrongAction)
                throw new Exception($"There was no action with your input: {userAction}. Try again!");

            if (userAction == Login)
            {
                LoginToApp(usernames, passwords);
            }
            else if (userAction == Register)
            {
                RegisterToApp(usernames);
            }
            else if (userAction == Exit)
            {
                ExitApp();
            }
        }

        static void LoginToApp(string[] usernames, string[] passwords)
        {
            string userInputtedUsername = PromptStringInput("What's your username?");
            string userInputtedPassword = PromptStringInput("What's your password?");

            bool userWasNotFound = !IsUserInDatabase(usernames, passwords, userInputtedUsername, userInputtedPassword);
            if (userWasNotFound) throw new UsersNotFoundException("Username or password was wrong! Try again.");
            else Console.WriteLine("Login was succesful. Welcome!");
            
        }

        static void RegisterToApp(string[] usernames)
        {
            string selectedUsernameByUser = PromptStringInput("What username you want to use?");
            string selecterdPasswordByUser = PromptStringInput("What password you want to use?");

            bool userDuplicateFound = IsUserAlreadyInDatabase(usernames, selectedUsernameByUser);
            var duplicateUserException = new DuplicateUserCredentialsException("Such username is already in database! Try another username.");
            if (userDuplicateFound) throw duplicateUserException;

            AppendUserToDatabase(Path, selectedUsernameByUser, selecterdPasswordByUser);
            Console.WriteLine($"{selectedUsernameByUser} has been succesfully registered to the app!");
        }

        static void ExitApp()
        {
            Console.WriteLine("Program is being closed!");
            Environment.Exit(0);
        }

        static string PromptStringInput(string question)
        {
            Console.Write($"{question} ");
            string userInput = Console.ReadLine();
            return userInput;
        }

        static bool IsUserInDatabase(string[] usernames, string[] passwords, string usernameByUser, string passwordByUser)
        {
            for (int i = 0; i < usernames.Length; i++)
            {
                bool informationIsCorrect = usernames[i].Equals(usernameByUser, StringComparison.OrdinalIgnoreCase) &&
                    passwords[i].Equals(passwordByUser);

                if (informationIsCorrect) return true;
            }

            return false;
        }

        static bool IsUserAlreadyInDatabase(string[] usernames, string usernameByUser)
        {
            for (int i = 0; i < usernames.Length; i++)
            {
                if (usernames[i].Equals(usernameByUser, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        static void AppendUserToDatabase(string path, string username, string password)
        {
            bool appendToFile = true;
            using (StreamWriter stream = new StreamWriter(path, appendToFile))
            {
                stream.Write($"\n{username} {password}");
            }
        }
    }
}