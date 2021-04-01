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

            // Sort method.
            Console.WriteLine("\nTesting the Sort method:");
            string[] sortedFruits = Sort(fruits);

            Console.Write("Unsorted: ");
            Print(fruits);

            Console.Write("Sorted: ");
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
        }

        /// <summary>
        /// Sorts a copy of the string array in alphabetical order.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        /// <returns>A sorted copy of the specified array.</returns>
        public static string[] Sort(string[] array)
        {
            string[] sorted = Copy(array);

            for(int i = 0; i < sorted.Length; i++)
            {
                bool isShifted = false;

                for(int j = 0; j < sorted.Length; j++)
                {
                    // Check that this is not the last index in the array.
                    if(j != sorted.Length - 1)
                    {
                        string shiftedValue;

                        // Check if CompareTo() return 1. 
                        // If it does, switch positions.
                        if(sorted[j].CompareTo(sorted[j + 1]) == 1)
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
                if(!isShifted)
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
        public static string[] Copy(string[] array)
        {
            string[] newArray = new string[array.Length];

            Array.Copy(array, newArray, array.Length);

            return newArray;
        }

        /// <summary>
        /// Adds a specified value to the beginning of the specified array
        /// and returns the new array.
        /// </summary>
        /// <param name="array">The array to be changed.</param>
        /// <param name="value">The value to be added to the array.</param>
        /// <returns>A copy of the array with a new value added to the first index.</returns>
        public static string[] AddElementToStart(string[] array, string value)
        {
            string[] newArray = new string[array.Length + 1];

            newArray[0] = value;

            // Copy values from old array into new array.
            for(int i = 1; i < newArray.Length; i++)
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
        /// <returns>The new array with the specified value added to the last index.</returns>
        public static string[] AddElementToEnd(string[] array, string value)
        {
            string[] newArray = new string[array.Length + 1];

            // Copy values from old array into new array.
            for(int i = 0; i < array.Length; i++)
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
        /// <returns>A copy of the array with a new value added to the specified index.</returns>
        public static string[] AddElementAnywhere(string[] array, int index, string value)
        {
            string[] newArray = new string[array.Length + 1];

            newArray[index] = value;

            // Copy values from old array into the new array.
            // Skip over the newly added value.
            for(int i = 0; i < newArray.Length; i++)
            {
                if(i < index)
                {
                    newArray[i] = array[i];
                }

                if(i > index)
                {
                    newArray[i] = array[i - 1];
                }
            }

            return newArray;
        }

        /// <summary>
        /// Prints the array to the console.
        /// </summary>
        /// <param name="array">The array to be printed.</param>
        public static void Print(string[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if(i != array.Length - 1)
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
