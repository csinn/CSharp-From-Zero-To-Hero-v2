using System;

namespace Homework2
{
    class Program
    {
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

        //Variables
        private static bool loggedIn = false; // Variable to track if user is "logged in"
        private static string[][] userArray = new string[5][]; // array of user arrays with login info which is string[username,password]; Would rather use List<>
        

        static void Main(string[] args)
        {
            //Adding a couple of users to array
            userArray[0] = new string[] { "Admin", "slAptazodis" };
            userArray[1] = new string[] { "user1", "pSwD" };
            userArray[2] = new string[] { "LaIMONAS", "123" };
            userArray[3] = new string[] { "Xavier", "Dust" };
            userArray[4] = new string[] { "Blaber", "Lol" };
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
                Console.WriteLine("Select option:\n");
                Console.WriteLine("1 - Log in\n");
                Console.WriteLine("2 - Register\n");
            }

            OptionSelection(option: Console.ReadLine());
        }

        //Funtion that gets which option was selected and calls other needed functions via switch statement.
        static void OptionSelection(string option) {
            Console.Clear();
            switch (option)
            {
                case "1":
                    // Log in
                    Login();
                    break;
                case "2":
                    //Register / adding to end of list
                    PromptAddUserToArray();
                    break;
                case "3":
                    //Listing all users;
                    ListUsers();
                    break;
                case "4":
                    //Adding to start of list
                    PromptAddUserToArray(addToEnd: false, addToStart: true);
                    break;
                case "5":
                    //adding to end of list/ like register
                    PromptAddUserToArray();
                    break;
                case "6":
                    //Adding to n'th(index) position on list
                    PromptAddUserToArray(addToEnd: false, addToStart: false);
                    break;
                case "7":
                    //Remove from start of the array
                    PromptRemoveUser(removeFromEnd: false, removeFromStart: true);
                    break;
                case "8":
                    //Remove from end of the array
                    PromptRemoveUser(removeFromEnd: true, removeFromStart: false);
                    break;
                case "9":
                    //Prompt to get index of user to remove from array
                    PromptRemoveUser(removeFromEnd: false, removeFromStart: false);
                    break;
                case "10":
                    //Sorting array by usernames in ascending order
                    SortUsers();
                    break;
                case "11":
                    LogOut();
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
        static void Login() {
            Console.Clear();
            string username = PromptInput("Enter username:");
            string password = PromptInput("Enter password:");

            if (CheckIfUserExists(username))
            {
                Console.WriteLine("userexists");
                string[] userDetails = ReturnUserByUsername(username);
                Console.WriteLine(userDetails[0] + " " + userDetails[1]);
                if (userDetails[1] == password) {
                    loggedIn = true;
                    
                    MenuSelection();
                    return;
                }
            }

            if (RetryConfirmation("Bad username or password."))
            {
                Login();
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
        static bool CheckIfUserExists(string username) {
            for (int i = 0; i < userArray.Length; i++)
            {
                if (userArray[i][0].ToLower() == username.ToLower())
                {
                    Console.WriteLine("Found");
                    return true;
                }
            }
            return false;
        }

        // Look through user array for a username and return string array of username and password
        static string[] ReturnUserByUsername(string username) {
            string[] array = new string[] {"",""};
            for (int i = 0; i < userArray.Length; i++)
            {
                if (userArray[i][0].ToLower() == username.ToLower())
                {
                    array = userArray[i];
                }
            }
            return array;
        }

        //Adding string[] - [username,password] - user details to userArray at selected index.
        static void AddUserToArrayAtIndex(string[] userDetails, int index) {
            string[][] newArray = new string[userArray.Length + 1][];

            for (int i = 0; i < newArray.Length; i++)
            {
                if (index == 0 && i == 0 )
                {
                    newArray[i] = userDetails;
                    continue;
                }

                if (i < index)
                {
                    newArray[i] = userArray[i];
                }

                if (i==index)
                {
                    newArray[i] = userDetails;
                }

                if (i > index)
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
            
            int index = userArray.Length;

            if (addToStart)
            {
                index = 0;
            }

            if (!addToEnd && !addToStart)
            {
                string indexStr = PromptInput("Enter index to add user at:");
                index = int.Parse(indexStr);
            }

            if (index<0 || index > userArray.Length)
            {
                if (RetryConfirmation("Bad index."))
                {
                    PromptAddUserToArray(addToEnd,addToStart);
                }
                else
                {
                    MenuSelection();
                }
            }

            if (!CheckIfUserExists(username) || !(password == ""))
            {
                string[] userDetails = new string[2] { username, password };
                AddUserToArrayAtIndex(userDetails, index);
                ListUsers();
                return;
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

            int index = userArray.Length - 1;

            if (removeFromStart)
            {
                index = 0;
            }

            if (!removeFromEnd && !removeFromStart)
            {
                string indexStr = PromptInput("Enter index to remove user at:");
                index = int.Parse(indexStr);
            }

            if (index < 0 || index >= userArray.Length)
            {
                if (RetryConfirmation("Bad index."))
                {
                    PromptRemoveUser(removeFromEnd, removeFromStart);
                }
                else
                {
                    MenuSelection();
                }
            }

            RemoveUser(index);
            ListUsers();
        }

        //Remove user from userArray at index.
        static void RemoveUser(int index) {
            string[][] newArray = new string[userArray.Length - 1][];

            for (int i = 0; i < newArray.Length; i++)
            {
                if (i <index)
                {
                    newArray[i] = userArray[i];
                }

                if (i == index)
                {
                    newArray[i] = userArray[i + 1];
                }

                if (i > index)
                {
                    newArray[i] = userArray[i + 1];
                }
            }

            userArray = newArray;
        }

        //Sorting users
        static void SortUsers() {
            Console.Clear();
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
            }

            string[] temp;
            for (int j = 0; j < userArray.Length; j++)
            {
                for (int i = 0; i < userArray.Length - 1; i++)
                {
                    if (order == "1")
                    {
                        if (userArray[i][0].CompareTo(userArray[i + 1][0]) > 0)
                        {
                            temp = userArray[i];
                            userArray[i] = userArray[i + 1];
                            userArray[i + 1] = temp;
                        }
                    }
                    else {
                        if (userArray[i][0].CompareTo(userArray[i + 1][0]) < 0)
                        {
                            temp = userArray[i];
                            userArray[i] = userArray[i + 1];
                            userArray[i + 1] = temp;
                        }
                    }
                   
                }
            }
            ListUsers();
        }
    }
}
