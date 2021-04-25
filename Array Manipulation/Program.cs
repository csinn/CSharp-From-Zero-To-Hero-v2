using System;

namespace Array_Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {55, 2, 1, 4, 0};

            PrintArray(arr);

            int[] arr6 = SelectionSort(arr);
            PrintArray(arr6);
            Console.Write("Enter an integer to manipulate array: ");
            string textInput = Console.ReadLine();
            _ = int.TryParse(textInput, out int input);

            int[] arr1 = InsertAtEnd(arr, input);
            PrintArray(arr1);

            int[] arr2 = InsertAtStart(arr, input);
            PrintArray(arr2);

            int[] arr3 = RemoveFromEnd(arr);
            PrintArray(arr3);

            int[] arr4 = RemoveFromStart(arr);
            PrintArray(arr4);

            Console.Write("Enter the place of the number you want to delete from the array: ");
            textInput = Console.ReadLine();
            _ = int.TryParse(textInput, out input);

            int[] arr5 = RemoveAtIndex(arr, input);
            PrintArray(arr5);
        }

        static void PrintArray(int[] arr)
        {
            Console.Write("Array: ");
            foreach (var variable in arr)
            {
                Console.Write($"{variable} ");
            }
            Console.WriteLine();
        }

        static int[] SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int iMin = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[iMin] > arr[j])
                    {
                        iMin = j;
                    }
                }

                int temp = arr[i];
                arr[i] = arr[iMin];
                arr[iMin] = temp;
            }
            Console.Write("Array after Sorting: ");

            return arr;
        }

        static int[] InsertAtEnd(int[] arr, int value)
        {
            int newLength = arr.Length + 1;
            int[] arrFinal = new int[newLength];

            Array.Copy(arr, arrFinal, arr.Length);

            arrFinal[newLength - 1] = value;

            Console.Write("After Insertion At the End: ");

            return arrFinal;
        }

        static int[] InsertAtStart(int[] arr, int value)
        {
            int newLength = arr.Length + 1;
            int[] arrFinal = new int[newLength];

            Array.Copy(arr, 0, arrFinal, 1, arr.Length );

            arrFinal[0] = value;

            Console.Write("After Insertion At the Start: ");

            return arrFinal;
        }

        static int[] RemoveFromEnd(int[] arr)
        {
            int newLength = arr.Length - 1;
            int[] arrFinal = new int[newLength];

            Array.Copy(arr, arrFinal, newLength);

            Console.Write("After Removing From the End: ");

            return arrFinal;
        }

        static int[] RemoveFromStart(int[] arr)
        {
            int newLength = arr.Length - 1;     
            int[] arrFinal = new int[newLength];

            Array.Copy(arr, 1, arrFinal, 0, newLength);

            Console.Write("After Removing From the Start: ");

            return arrFinal;
        }

        static int[] RemoveAtIndex(int[] arr, int place)
        { 
            //fail safe
            while (place < 1 || place > arr.Length)
            {
                Console.WriteLine($"Invalid place, the value of place should be between 1 and {arr.Length}");
                Console.Write("Enter the place again: ");
                string temp = Console.ReadLine();
                _ = int.TryParse(temp, out place);
            }
            
            int newLength = arr.Length - 1;
            int[] arrFinal = new int[newLength];
            int index = place - 1;

            Array.Copy(arr, 0, arrFinal, 0, index);
            Array.Copy(arr, index + 1, arrFinal, index, newLength - index);

            Console.Write($"After Removing the value at {place}th place: ");

            return arrFinal;
        }
    }
}
