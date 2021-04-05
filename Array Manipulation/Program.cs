using System;

namespace Array_Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1, 2, 4, 5};

            PrintArray(arr);
            Console.WriteLine();

            InsertAtEnd(arr, 32);
            Console.WriteLine();

            InsertAtStart(arr, 32);
            Console.WriteLine();

            RemoveFromEnd(arr);
            Console.WriteLine();

            RemoveFromStart(arr);
        }

        static void PrintArray(int[] arr)
        {
            Console.Write("Array: ");
            foreach (var variable in arr)
            {
                Console.Write($"{variable} ");
            }
        }

        static void ArraySort(int[] arr)
        {

        }

        static void InsertAtEnd(int[] arr, int value)
        {
            int newLength = arr.Length + 1;
            int[] arrFinal = new int[newLength];

            for (int i = 0; i < arr.Length; i++)
            {
                arrFinal[i] = arr[i];
            }

            arrFinal[newLength - 1] = value;

            Console.Write("After Insertion At the End: ");
            PrintArray(arrFinal);
        }

        static void InsertAtStart(int[] arr, int value)
        {
            int newLength = arr.Length + 1;
            int[] arrFinal = new int[newLength];

            for (int i = arr.Length; i > 0; i--)
            {
                arrFinal[i] = arr[i-1];
            }

            arrFinal[0] = value;

            Console.Write("After Insertion At the Start: ");
            PrintArray(arrFinal);
        }

        static void RemoveFromEnd(int[] arr)
        {
            int newLength = arr.Length - 1;
            int[] arrFinal = new int[newLength];

            for (int i = 0; i < arrFinal.Length; i++)
            {
                arrFinal[i] = arr[i];
            }

            Console.Write("After Removing From the End: ");
            PrintArray(arrFinal);
        }

        static void RemoveFromStart(int[] arr)
        {
            int newLength = arr.Length - 1;     
            int[] arrFinal = new int[newLength];

            for (int i = arrFinal.Length - 1; i <= 0; i--)
            {
                arrFinal[i] = arr[i + 1];
            }

            Console.Write("After Removing From the Start: ");
            PrintArray(arrFinal);
        }
    }
}
