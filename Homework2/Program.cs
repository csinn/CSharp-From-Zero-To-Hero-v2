using System;

namespace Homework2
{
    class Program
    {
        static string username, password;
        static void Main(string[] args)
        {

            int[] originalArray = { 8, 4, 0, 21, 32, 5, 7, 17, 29, 44, 2, 1, 4 };
            Console.WriteLine($"Original array: {string.Join(" ", originalArray)}");

            // Sorting
            Console.WriteLine($"After sorting: {string.Join(" ", SortArray(originalArray))}");

            // Add item to start
            Console.WriteLine($"After adding to the start: {string.Join(" ", AddToStart(originalArray, -100))}");

            // Add item to end
            Console.WriteLine($"After adding to the end: {string.Join(" ", AddToEnd(originalArray, -100))}");

            // Add item at any index
            int inserIndex = -1;
            while (inserIndex < 0 || inserIndex >= originalArray.Length)
            {
                Console.Write($"Enter an integer between 0 and {originalArray.Length - 1} (inclusive): ");
                inserIndex = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"After inserting at {inserIndex}: {string.Join(" ", AddToArray(originalArray, -100, inserIndex))}");

            // Remove from the start
            Console.WriteLine($"After removing from the start: {string.Join(" ", RemoveFromStart(originalArray))}");

            // Remove from the end
            Console.WriteLine($"After removing from the end: {string.Join(" ", RemoveFromEnd(originalArray))}");

            // Remove from any index
            int removeIndex = -1;
            while (removeIndex < 0 || removeIndex >= originalArray.Length)
            {
                Console.Write($"Enter an integer between 0 and {originalArray.Length - 1} (inclusive): ");
                removeIndex = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"After removing from {removeIndex}: {string.Join(" ", RemoveFromArray(originalArray, removeIndex))}");

            SignUp();
            
        }

        static int[] SortArray(int[] arr)
        {
            int[] copiedArray = new int[arr.Length];
            Array.Copy(arr, copiedArray, arr.Length);
            for (int i = 0; i < copiedArray.Length - 1; i++)
            {
                int j;
                int minimum = copiedArray[i];
                int minIndex = i;
                for (j = i + 1; j < copiedArray.Length; j++)
                {
                    if (copiedArray[j] < minimum)
                    {
                        minimum = copiedArray[j];
                        minIndex = j;
                    }
                }
                int temp = copiedArray[i];
                copiedArray[i] = minimum;
                copiedArray[minIndex] = temp;
            }
            return copiedArray;
        }

        static int[] AddToStart(int[] arr, int item)
        {
            int[] copiedArray = new int[arr.Length + 1];
            Array.Copy(arr, 0, copiedArray, 1, arr.Length);
            copiedArray[0] = item;
            return copiedArray;
        }

        static int[] AddToEnd(int[] arr, int item)
        {
            int[] copiedArray = new int[arr.Length + 1];
            Array.Copy(arr, copiedArray, arr.Length);
            copiedArray[copiedArray.Length - 1] = item;
            return copiedArray;
        }

        static int[] AddToArray(int[] arr, int item, int index)
        {
            if (index == 0) return AddToStart(arr, item);
            else if (index == arr.Length - 1) return AddToEnd(arr, item);
            int[] copiedArray = new int[arr.Length + 1];
            Array.Copy(arr, copiedArray, index);
            copiedArray[index] = item;
            Array.Copy(arr, index, copiedArray, index + 1, arr.Length - index);
            return copiedArray;
        }

        static int[] RemoveFromStart(int[] arr)
        {
            int[] copiedArray = new int[arr.Length - 1];
            Array.Copy(arr, 1, copiedArray, 0, copiedArray.Length);
            return copiedArray;
        }

        static int[] RemoveFromEnd(int[] arr)
        {
            int[] copiedArray = new int[arr.Length - 1];
            Array.Copy(arr, copiedArray, copiedArray.Length);
            return copiedArray;
        }

        static int[] RemoveFromArray(int[] arr, int index)
        {
            if (index == 0) return RemoveFromStart(arr);
            else if (index == arr.Length - 1) return RemoveFromEnd(arr);
            int[] copiedArray = new int[arr.Length - 1];
            Array.Copy(arr, copiedArray, index);
            Array.Copy(arr, index + 1, copiedArray, index, copiedArray.Length - index);
            return copiedArray;
        }

        static void SignUp()
        {
            Console.Write("Add an username:");
            username = Console.ReadLine();
            Console.Write("Add a password:");
            password = Console.ReadLine();
            Login();
        }

        static void Login()
        {
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("First sign up, please");
                SignUp();
                return;
            }
            int option = -1;
            while (option != 0)
            {
                Console.Write("Enter your username:");
                string typedName = Console.ReadLine();
                Console.Write("Enter your password:");
                string typedPassword = Console.ReadLine();
                if(typedName.ToLower() == username.ToLower() && typedPassword == password)
                {
                    Console.WriteLine("Logged in!");
                    return;
                }
                else
                {
                    Console.WriteLine("Wrong credentials");
                    Console.Write("Enter 1 to create new account, 0 to exit and another number to try again:");
                    option = int.Parse(Console.ReadLine());
                    if (option == 1)
                    {
                        SignUp();
                        return;
                    }
                }
            }
            Console.WriteLine("Exiting..");
            return;
        }
    }
}
