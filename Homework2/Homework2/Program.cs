using System;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {4, 3, 6, 43, 54, 21, 2, 14, 1, 5, 7, 41, 22};
            SortArray(array);

            AddToArrayOptions(array);

            RemoveOutOfArrayOptions(array);

            AccountOptions();

            Console.ReadKey();
        }

        static void PrintArray(int[] array)
        {
            var numbers = string.Join(" ", array);
            Console.WriteLine(numbers);
        }

        static void SortArray(int[] array) // Sort an array
        {
            Console.WriteLine("=== SORTING AN ARRAY ===");
            int[] NewArray = new int[array.Length];
            Array.Copy(array, NewArray, array.Length);

            for (int i = NewArray.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (NewArray[j] > NewArray[j + 1])
                    {
                        int temp = NewArray[j + 1];
                        NewArray[j + 1] = NewArray[j];
                        NewArray[j] = temp;
                    }
                }
            }

            PrintArray(NewArray);
        }

        #region AddToArray

        static void AddToArrayOptions(int[] array)
        {
            AddToStart(array);
            AddToEnd(array);
            AddToArray(array);
        }

        static void AddToStart(int[] array) // Add element at the start of an array
        {
            Console.WriteLine("\n=== ADDING NUMBER TO THE START ===");
            Console.Write("What Number would you like to add at the start? ");
            int.TryParse(Console.ReadLine(), out int num);
            AddToArrayPosition(num, 0, array);
        }

        static void AddToEnd(int[] array) // Add element at the end of an array
        {
            Console.WriteLine("\n=== ADDING NUMBER TO THE END ===");
            Console.Write("What Number would you like to add at the end? ");
            int.TryParse(Console.ReadLine(), out int num);
            AddToArrayPosition(num, array.Length, array);
        }

        static void AddToArray(int[] array)
        {
            Console.WriteLine("\n=== ADDING NUMBER TO ANY POSITION ===");
            Console.Write("What position would you like to add a number to? ");
            int.TryParse(Console.ReadLine(), out int position2);
            Console.Write("What Number would you like to add? ");
            int.TryParse(Console.ReadLine(), out int num3);

            AddToArrayPosition(num3, position2, array);
        }

        static void AddToArrayPosition(int num, int position, int[] array) // Add element at any position of an array
        {
            int[] NewArray = new int[array.Length + 1];
            int temp = 0;

            for (int index = 0; index < NewArray.Length; index++)
            {
                if (index != position)
                {
                    NewArray[index] = array[temp++];
                }
                else
                {
                    NewArray[index] = num;
                }
            }

            PrintArray(NewArray);
        }

        #endregion

        #region RemoveFromArray

        static void RemoveOutOfArrayOptions(int[] array)
        {
            Console.WriteLine("\n=== REMOVING NUMBER FROM THE START ===");
            RemoveAtStart(array);

            Console.WriteLine("\n=== REMOVING NUMBER FROM THE END ===");
            RemoveAtEnd(array);

            Console.WriteLine("\n=== REMOVING NUMBER FROM ANY POSITION ===");
            Console.Write("\nWhat position would you like to remove? ");
            int.TryParse(Console.ReadLine(), out int position);
            RemoveAtAny(array, position);
        }

        static void RemoveAtStart(int[] array) // Remove element at the start of an array
        {
            RemoveAtAny(array, 0);
        }

        static void RemoveAtEnd(int[] array) // Remove element at the end of an array
        {
            RemoveAtAny(array, array.Length);
        }

        static void RemoveAtAny(int[] array, int position) // Remove element at a given index of an array
        {
            int[] NewArray = new int[array.Length - 1];
            int temp = 0;
            for (int index = 0; index < array.Length; index++)
            {
                if (index != position && temp != NewArray.Length)
                {
                    NewArray[temp++] = array[index];
                }
            }

            PrintArray(NewArray);
        }

        #endregion

        #region Login

        static string RegisteredUsername { get; set; }
        static string RegisteredPassword { get; set; }

        static void AccountOptions()
        {
            SignUp();
            Login();
        }

        public static void SignUp() // sign up
        {
            Console.WriteLine("\n=== SIGN UP ===");
            Console.Write("Username: ");
            RegisteredUsername = Console.ReadLine();
            Console.Write("Password: ");
            RegisteredPassword = Console.ReadLine();
        }

        public static void Login() // log in
        {
            Console.WriteLine("\n=== LOGIN ===");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (username.ToLower() == RegisteredUsername.ToLower() && password == RegisteredPassword)
            {
                Console.WriteLine("Logged in!");
            }
            else
            {
                Console.WriteLine("Incorrect Credentials");
            }
        }

        #endregion
    }
}