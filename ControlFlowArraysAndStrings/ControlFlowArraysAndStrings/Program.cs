using System;

namespace ControlFlowArraysAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruits = { "banana",
                                "apple", 
                                "orange", 
                                "pineapple", 
                                "blueberry",
                                "raspberry",
                                "apricot" };

            string[] sortedFruits = SortArray(fruits);

            Console.Write("Unsorted: ");
            PrintArray(fruits);

            Console.Write("Sorted: ");
            PrintArray(sortedFruits);
        }

        /// <summary>
        /// Sorts a copy of the string array in alphabetical order.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        /// <returns>A sorted copy of the specified array.</returns>
        public static string[] SortArray(string[] array)
        {
            string[] sorted = CopyStringArray(array);

            for (int i = 0; i < sorted.Length; i++)
            {
                bool isShifted = false;

                for (int j = 0; j < sorted.Length; j++)
                {
                    // Check that this is not the last index in the array.
                    if (j != sorted.Length - 1)
                    {
                        string shiftedValue;

                        // Check if CompareTo() return 1. 
                        // If it does, switch positions.
                        if (sorted[j].CompareTo(sorted[j + 1]) == 1)
                        {
                            shiftedValue = sorted[j];

                            sorted[j] = sorted[j + 1];

                            sorted[j + 1] = shiftedValue;

                            isShifted = true;
                        }
                    }             
                }

                // If no value has been changed after one full pass 
                // of the inner loop, break out of the outer loop.
                if (!isShifted)
                {
                    break;
                }
            }

            return sorted;
        }

        /// <summary>
        /// Copies the specified array and returns a new array.
        /// </summary>
        /// <param name="array">The array to be copied.</param>
        /// <returns>A copy of the specified array.</returns>
        public static string[] CopyStringArray(string[] array)
        {
            string[] newArray = new string[array.Length];

            Array.Copy(array, newArray, array.Length);

            return newArray;
        }

        /// <summary>
        /// Prints the array to the console.
        /// </summary>
        /// <param name="array">The array to be printed.</param>
        public static void PrintArray(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i != array.Length - 1)
                {
                    Console.Write(array[i] + ", ");
                }
                else
                {
                    Console.Write(array[i] + "\n");
                }
            }
        }
    }
}
