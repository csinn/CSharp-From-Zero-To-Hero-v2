using System;

namespace ControlFlowArraysAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruits = { "banana",
                                "pineapple",
                                "apple",
                                "orange",
                                "blueberry",
                                "raspberry",
                                "apricot" };

            // Original Array.
            Console.WriteLine("Original Array: ");
            Print(fruits);

            // Sort method.
            Console.WriteLine("\nTesting the Sort method:");
            string[] sortedFruits = Sort(fruits);
            Print(sortedFruits);

            // AddElementToStart method.
            Console.WriteLine("\nTesting the AddElementToStart method:");
            string[] addWatermelon = AddElementToStart(fruits, "watermelon");
            Print(addWatermelon);

            // AddElementToEnd method.
            Console.WriteLine("\nTesting the AddElementToEnd method:");
            string[] addKiwi = AddElementToEnd(fruits, "kiwi");
            Print(addKiwi);

            // AddElementAnywhere method.
            Console.WriteLine("\nTesting the AddElementAnywhere method:");
            string[] addLime = AddElementAnywhere(fruits, 3, "lime");
            Print(addLime);

            string[] addLime2 = AddElementAnywhere(fruits, 7, "lime");
            Print(addLime2);

            string[] addLime3 = AddElementAnywhere(fruits, 0, "lime");
            Print(addLime3);

            // RemoveElementFromStart method.
            Console.WriteLine("\nTesting the RemoveElementFromStart method:");
            string[] removeBanana = RemoveElementFromStart(fruits);
            Print(removeBanana);

            // RemoveElementFromEnd method.
            Console.WriteLine("\nTesting the RemoveElementFromEnd method:");
            string[] removeApricot = RemoveElementFromEnd(fruits);
            Print(removeApricot);

            // RemoveElementFromAnywhere method.
            Console.WriteLine("\nTesting the RemoveElementFromAnywhere method:");
            string[] removePineapple = RemoveElementFromAnywhere(fruits, 3);
            Print(removePineapple);

            string[] removeStart = RemoveElementFromAnywhere(fruits, 0);
            Print(removeStart);

            string[] removeEnd = RemoveElementFromAnywhere(fruits, 6);
            Print(removeEnd);

            // Login method.
            Console.WriteLine("\nTesting the Login method:");
            Login();
        }

        /// <summary>
        /// Sorts a copy of the string array in alphabetical order.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        /// <returns>A sorted copy of the specified array.</returns>
        public static string[] Sort(string[] array)
        {
            string[] sorted = Copy(array);

            for (int i = 0; i < sorted.Length - 1; i++)
            {
                for (int j = 0; j < sorted.Length - i - 1; j++)
                {
                    // Check if CompareTo() returns 1, if it does, swap positions.
                    if (sorted[j].CompareTo(sorted[j + 1]) == 1)
                    {
                        string shiftedValue = sorted[j];
                        sorted[j] = sorted[j + 1];
                        sorted[j + 1] = shiftedValue;
                    }
                }
            }

            return sorted;
        }

        /// <summary>
        /// Copies the specified array and returns a new array.
        /// </summary>
        /// <param name="array">The array to be copied.</param>
        /// <returns>A copy of the specified array.</returns>
        public static string[] Copy(string[] array)
        {
            string[] newArray = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        /// <summary>
        /// Prints the array to the console.
        /// </summary>
        /// <param name="array">The array to be printed.</param>
        public static void Print(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i != array.Length - 1)
                {
                    Console.Write($"{array[i]}, ");
                }
                else
                {
                    Console.Write($"{array[i]}\n");
                }
            }
        }

        /// <summary>
        /// Adds a specified value to the beginning of the specified array
        /// and returns the new array.
        /// </summary>
        /// <param name="array">The array to be changed.</param>
        /// <param name="value">The value to be added to the array.</param>
        /// <returns>A new array with a value added to the first index.</returns>
        public static string[] AddElementToStart(string[] array, string value)
        {
            string[] newArray = new string[array.Length + 1];

            newArray[0] = value;

            for (int i = 1; i < newArray.Length; i++)
            {
                newArray[i] = array[i - 1];
            }

            return newArray;
        }

        /// <summary>
        /// Adds a specified value to the end of the specified array
        /// and returns the new array.
        /// </summary>
        /// <param name="array">The array to be changed.</param>
        /// <param name="value">The value to be added to the array.</param>
        /// <returns>The new array with a value added to the last index.</returns>
        public static string[] AddElementToEnd(string[] array, string value)
        {
            string[] newArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            newArray[newArray.Length - 1] = value;

            return newArray;
        }

        /// <summary>
        /// Adds a specified value to the specified index of the specified array
        /// and returns the new array.
        /// </summary>
        /// <param name="array">The array to be changed.</param>
        /// <param name="value">The index where the new value should be added.</param>
        /// <param name="value">The value to be added to the array.</param>
        /// <returns>A new array with a value added to the specified index.</returns>
        public static string[] AddElementAnywhere(string[] array, int index, string value)
        {
            string[] newArray = new string[array.Length + 1];

            newArray[index] = value;

            // Copy values from old array into the new array.
            // Skip over the newly added value.
            for (int i = 0; i < newArray.Length; i++)
            {
                if (i < index)
                {
                    newArray[i] = array[i];
                }

                if (i > index)
                {
                    newArray[i] = array[i - 1];
                }
            }

            return newArray;
        }

        /// <summary>
        /// Removes the value at the beginning of a specified array.
        /// </summary>
        /// <param name="array">The array to be changed.</param>
        /// <returns>A new array with a value removed from the start.</returns>
        public static string[] RemoveElementFromStart(string[] array)
        {
            string[] newArray = new string[array.Length - 1];

            for (int i = 1; i < array.Length; i++)
            {
                newArray[i - 1] = array[i];
            }

            return newArray;
        }

        /// <summary>
        /// Removes the value at the end of the specified array.
        /// </summary>
        /// <param name="array">The array to be changed.</param>
        /// <returns>A new array with a value removed from the end.</returns>
        public static string[] RemoveElementFromEnd(string[] array)
        {
            string[] newArray = new string[array.Length - 1];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        /// <summary>
        /// Removes the value at the specified index from the specified array.
        /// </summary>
        /// <param name="array">The array to be changed.</param>
        /// <param name="index">The index to be removed.</param>
        /// <returns>A new array with a value removed.</returns>
        public static string[] RemoveElementFromAnywhere(string[] array, int index)
        {
            string[] newArray = new string[array.Length - 1];

            for (int i = 0; i < newArray.Length; i++)
            {
                if (i < index)
                {
                    newArray[i] = array[i];
                }

                if (i >= index)
                {
                    newArray[i] = array[i + 1];
                }
            }

            return newArray;
        }

        /// <summary>
        /// Attempts to log in a user and prints a message to the console if login 
        /// was successful or unsuccessful. Allows 3 unsuccessful attempts before lock out.
        /// </summary>
        public static void Login()
        {
            int loginAttempts = 3;
            string[] credentialType = { "user name", "password"};
            bool[] isValid = { false, false };

            for (int i = 0; i < credentialType.Length; i++)
            {
                while (!isValid[i] && loginAttempts != 0)
                {
                    string credential = GetLoginCredentialsFromUser(credentialType[i]);
                    isValid[i] = ValidateCredential(credentialType[i], credential);

                    if (!isValid[i])
                    {
                        loginAttempts--;
                        Console.WriteLine($"Invalid {credentialType[i]}. {loginAttempts} tries left.");
                    }

                    if (loginAttempts == 0)
                    {
                        Console.WriteLine("You have been locked out. Please contact your system administrator.");
                        break;
                    }
                }
            }

            if (isValid[0] && isValid[1])
            {
                Console.WriteLine("Logged in!");
            }
        }

        /// <summary>
        /// Gets the login credentials from the user.
        /// </summary>
        /// <returns>The user name.</returns>
        public static string GetLoginCredentialsFromUser(string credentialType)
        {
            Console.Write($"Please enter your {credentialType}: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Validates the specified user name or password against a hidden value.
        /// </summary>
        /// <param name="credentialType">The type of credential.</param>
        /// <param name="credential">The credential to be validated.</param>
        /// <returns>True if valid, or false if invalid.</returns>
        public static bool ValidateCredential(string credentialType, string credential)
        {
            bool isValid = false;

            if (credentialType.ToLower().Equals("user name"))
            {
                string hiddenUsername = "CSharp";
                isValid = credential.Equals(hiddenUsername,
                                               StringComparison.OrdinalIgnoreCase);
            }

            if (credentialType.ToLower().Equals("password"))
            {
                string hiddenPassword = "Password123";
                isValid = credential.Equals(hiddenPassword);
            }

            return isValid;
        }
    }
}
