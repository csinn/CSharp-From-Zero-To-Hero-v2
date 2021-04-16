using System;
using System.IO;

namespace Homework2
{
    class Program
    {

        //HW2
        //
        //Create a method for each operation:
        //Sort an array
        //Add element at the start of an array
        //Add element at the end of an array
        //Add element at any position of an array
        //Remove element at the start of an array
        //Remove element at the end of an array
        //Remove element at a given index of an array
        //Login: takes username and password.If they match a hidden username and password- a message "Logged in!" is printed.
        //Username capitalization does not matter, password capitalization must match.

        //HW 3
        //
        //You have a file called Users.txt. It contains usernames and passwords. A user open your application and they have 3 options:
        //Login- enter their username and password, which should match any one line in Users.txt. Successful login will result in "Hello!" printed.
        //Register- enter their username and password, which should append their credentials at the end of the file. In case of a duplicate user- try again.
        //Exit- close the application
        //Users.txt file should be at the same directory as the application start .exe.
        //
        //Errors
        //If there is no Users.txt file- the application should not throw "UsersNotFoundException.
        //If a Users.text file contains duplicate users, throw a DuplicateUserCredentialsException.
        //
        //Restrictions
        //Don't use File class static methods.



        //Variables
        private static bool loggedIn = false; // Variable to track if user is "logged in"
        private static string[][] userArray = new string[0][]; // array of user arrays with login info which is string[username,password]
        private static string pathToFile = $"{Environment.CurrentDirectory}\\users.txt"; // path to user file 

        static void Main(string[] args)
        {
            LoadUsersFromFile();
            MenuSelection();
        }

        //Main function which lists available options
        static void MenuSelection() {
            Console.Clear();
            if (loggedIn)
            {
                Console.WriteLine("Logged in. \n\n");
                Console.WriteLine("3 - List users\n");
                Console.WriteLine("4 - Add user to start of list\n");
                Console.WriteLine("5 - Add user to end of list\n");
                Console.WriteLine("6 - Add user to n'th position in list\n");
                Console.WriteLine("7 - Remove user from start of list\n");
                Console.WriteLine("8 - Remove user from end of list\n");
                Console.WriteLine("9 - Remove n'th user\n");
                Console.WriteLine("10 - Sort users by username (asc/dec)\n");
                Console.WriteLine("11 - Log out\n");
            }
            else {
                Console.WriteLine("Select option:\n\n");
                Console.WriteLine("1 - Log in\n");
                Console.WriteLine("2 - Register\n");
            }

            Console.WriteLine("12 - Close console\n");

            OptionSelection(option: Console.ReadLine());
        }

        // Loading users from file to array - HW3  / User details should follow this format: username;password - in different line for each user.
        // Things to consider: line validation - multiple ;, empty usernames/passwords // ; char should also be validated on user creation
        static void LoadUsersFromFile() {
            try
            {
                CheckIfUsersFileExists();
                ReadUsersFileAndAddUsers();
            }
            catch (UsersNotFoundException fileEx)
            {
                throw;
            }
            catch (DuplicateUserCredentialsException usersEx)
            {
                throw;
            }
            catch (Exception defaultEx)
            { 
                throw;
            }
        }

        static void CheckIfUsersFileExists()
        {
            FileInfo file = new FileInfo(pathToFile);
            if (!file.Exists)
            {
                throw new UsersNotFoundException();
            }
        }

        static void ReadUsersFileAndAddUsers() {
            using (StreamReader reader = new StreamReader(pathToFile))
            {
                while (!reader.EndOfStream)
                {
                    string[] userCredentials = reader.ReadLine().Split(';');
                    if (CheckIfUserExists(userCredentials[0]))
                    {
                        throw new DuplicateUserCredentialsException(userCredentials[0]);
                    }
                    else
                    {
                        AddUserToArrayAtIndex(userCredentials, userArray.Length);
                    }
                }
            }
        }

        // Function to write user info from userArray to users.txt file
        static void WriteUsersToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(pathToFile,false))
                {
                    for (int i = 0; i < userArray.Length; i++)
                    {
                        writer.WriteLine($"{userArray[i][0]};{userArray[i][1]}");
                    }
                }
            }
            catch (Exception defaultEx)
            {
                throw;
            }
        }

        //Funtion that gets which option was selected and calls other needed functions via switch statement.
        static void OptionSelection(string option) {
            Console.Clear();
            switch (option)
            {
                case "1":
                    LogIn();
                    break;
                case "2":
                    PromptAddUserToArray();
                    break;
                case "3":
                    ListUsers();
                    break;
                case "4":
                    PromptAddUserToArray(addToEnd: false, addToStart: true);
                    break;
                case "5":
                    PromptAddUserToArray();
                    break;
                case "6":
                    PromptAddUserToArray(addToEnd: false, addToStart: false);
                    break;
                case "7":
                    PromptRemoveUser(removeFromEnd: false, removeFromStart: true);
                    break;
                case "8":
                    PromptRemoveUser(removeFromEnd: true, removeFromStart: false);
                    break;
                case "9":
                    PromptRemoveUser(removeFromEnd: false, removeFromStart: false);
                    break;
                case "10":
                    SortUsers();
                    break;
                case "11":
                    LogOut();
                    break;
                case "12":
                    WriteUsersToFile();
                    Environment.Exit(0);
                    break;
                default:
                    MenuSelection();
                    break;
            }
        }

        static string PromptInput(string message) {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        //Login function - gets username/password and checks against array
        static void LogIn() {
            Console.Clear();
            string username = PromptInput("Enter username:");
            string password = PromptInput("Enter password:");

            if (CheckIfUserExists(username))
            {
                string[] userDetails = ReturnUserByUsername(username);
                if (userDetails[1] == password) {
                    loggedIn = true;
                    MenuSelection();
                    return;
                }
            }

            if (RetryConfirmation("Bad username or password."))
            {
                LogIn();
            }
            else {
                MenuSelection();
            }
        }

        static void LogOut() {
            Console.Clear();
            loggedIn = false;
            MenuSelection();
        }

        // Function to display error message and return true for retry;
        static bool RetryConfirmation(string messageToDisplay) {
            Console.Clear();
            Console.WriteLine(messageToDisplay+" Retry? y/n");

            if (Console.ReadLine().ToLower() == "y")
            {
                return true;
            }
            return false;
        }


        // Returns true if username is found
        static bool CheckIfUserExists(string username)
        {
            return ReturnUserByUsername(username) != null;
        }

        // Look through user array for a username and return string array of username and password
        static string[] ReturnUserByUsername(string username) {
            for (int i = 0; i < userArray.Length; i++)
            {
                if (userArray[i][0].ToLower() == username.ToLower())
                {
                    return userArray[i];
                }
            }
            return null;
        }

        //Adding string[] - [username,password] - user details to userArray at selected index.
        static void AddUserToArrayAtIndex(string[] userDetails, int index) {
            string[][] newArray = new string[userArray.Length + 1][];

            for (int i = 0; i < newArray.Length; i++)
            {
                if (index == 0 && i == 0 )
                {
                    newArray[i] = userDetails;
                }else if(i < index)
                {
                    newArray[i] = userArray[i];
                }else if (i == index)
                {
                    newArray[i] = userDetails;
                }else if (i > index)
                {
                    newArray[i] = userArray[i - 1];
                }
            }

            userArray = newArray;
        }

        //Function to list users;
        static void ListUsers() {
            Console.Clear();
            Console.WriteLine("Users:\n");

            for (int i = 0; i < userArray.Length; i++)
            {
                Console.WriteLine(userArray[i][0]);
            }
            PromptInput("\nPress any key to continue.");
            MenuSelection();
        }

        //Function to add userDetails to end or start of userArray. Taking bool variables to determine whether add to start or end or select index.
        static void PromptAddUserToArray(bool addToEnd = true,bool addToStart = false) {
            Console.Clear();
            Console.WriteLine("Adding user:\n");

            string username = PromptInput("Enter username:");
            string password = PromptInput("Enter password:");


            int index = GetIndex(addToEnd, addToStart);

            if (!CheckIfUserExists(username) && !(password == "") && index != -1)
            {
                string[] userDetails = new string[2] { username, password };
                AddUserToArrayAtIndex(userDetails, index);
                WriteUsersToFile();
                ListUsers();
            }
            else {
                if (RetryConfirmation("Bad user details."))
                {
                    PromptAddUserToArray(addToEnd, addToStart);
                }
                else
                {
                    MenuSelection();
                }
            }
        }

        //Function to get index of where user should be removed
        static void PromptRemoveUser(bool removeFromEnd = true, bool removeFromStart = false) {
            Console.Clear();
            int index = GetIndex(removeFromEnd, removeFromStart);
            if (index != -1)
            {
                RemoveUser(index);
                WriteUsersToFile();
                ListUsers();
            }
            else if (RetryConfirmation("Index error"))
            {
                PromptRemoveUser(removeFromEnd, removeFromStart);
            }
            else {
                MenuSelection();
            }
        }

        //returns or prompts index for array. Returns -1 if there are issues.
        static int GetIndex(bool endOfArray = true, bool startOfArray = false) {
            if (endOfArray)
            {
                return userArray.Length;
            }
            else if (startOfArray)
            {
                return 0;
            }
            else if (!endOfArray && !startOfArray)
            {
                string indexStr = PromptInput("Enter index:");
                int.TryParse(indexStr, out int index);

                if (index < 0 || index >= userArray.Length)
                {
                    return -1;
                }
                else {
                    return index;
                }
            }
            return -1;
        }


        //Remove user from userArray at index.
        static void RemoveUser(int index) {
            string[][] newArray = new string[userArray.Length - 1][];

            for (int i = 0; i < newArray.Length; i++)
            {
                if (i < index)
                {
                    newArray[i] = userArray[i];
                }else
                {
                    newArray[i] = userArray[i + 1];
                }
            }

            userArray = newArray;
        }

        //Sorting users
        static void SortUsers() {
            Console.Clear();
            bool order = ReturnSortingOrder();
            SortUserArray(order);
            WriteUsersToFile();
            ListUsers();
        }

        // Function to swap values in userArray
        static void UserArrayValueSwap(int x, int y) {
            string[] temp;
            temp = userArray[x];
            userArray[x] = userArray[y];
            userArray[y] = temp;
        }


        //sorting function, if true is passed sorts in asc, if flase - in descending
        static void SortUserArray(bool sortOrder) {
            for (int j = userArray.Length; j >= 0 ; j--)
            {
                bool sorted = true;
                for (int i = 0; i < userArray.Length - 1; i++)
                {
                    if (sortOrder)
                    {
                        if (userArray[i][0].CompareTo(userArray[i + 1][0]) > 0)
                        {
                            UserArrayValueSwap(i, i + 1);
                            i++;
                            sorted = false;
                        }
                    }
                    else {
                        if (userArray[i][0].CompareTo(userArray[i + 1][0]) < 0)
                        {
                            UserArrayValueSwap(i, i + 1);
                            i++;
                            sorted = false;
                        }
                    }
                }
                if (sorted)
                {
                    return;
                }
            }
        }

        //True for ascending/ false for descending
        static bool ReturnSortingOrder()
        {
            string order = PromptInput("Choose sort type:\n1 - asc\n2 - dec");
            if (order != "1" && order != "2")
            {
                if (RetryConfirmation("Bad sort selected"))
                {
                    SortUsers();
                }
                else
                {
                    MenuSelection();
                }
                return false;
            }
            else if (order == "1")
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }

    class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException(string name)
         : base(String.Format("Duplicate users found: {0}", name))
        {
            
        }
    }

    class UsersNotFoundException : Exception {
        public UsersNotFoundException()
         : base(String.Format("File not found."))
        {

        }
    }
}
