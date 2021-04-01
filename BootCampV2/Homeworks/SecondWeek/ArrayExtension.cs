using System;

namespace BootCampV2
{
    public class ArrayExtension
    {
        /// <summary>
        /// Use the bubble sort algorithm to sort an array
        /// <para> return: sorted Array </para> 
        /// </summary>
        public static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                bool swap = false;
                for (int m = 0; m < (array.Length - i) - 1; m++)
                {
                    if (array[m] > array[m + 1])
                    {
                        array = SwapElements(array, m, m + 1);
                        swap = true;
                    }
                }
                if (!swap)
                    break;
            }
            return array;
        }


        /// <summary>
        /// Swap two elements with each other
        /// <para> return: modified Array </para> 
        /// </summary>
        public static int[] SwapElements(int[] array, int firstIndex, int secondIndex)
        {
            if (firstIndex >= array.Length || firstIndex < 0 ||
                secondIndex >= array.Length || secondIndex < 0)
                throw new ArgumentOutOfRangeException();

            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;

            return array;
        }

        /// <summary>
        /// Insert an element at the start of the array
        /// <para> return: modified Array </para> 
        /// </summary>

        public static T[] AppendToStart<T>(T[] array, T element)
        {
            T[] expandedArray = new T[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
                expandedArray[i + 1] = array[i];

            expandedArray[0] = element;

            return expandedArray;
        }

        /// <summary>
        /// Insert an element at the given position in the array
        /// <para> return: modified Array </para> 
        /// </summary>

        public static T[] InsertAt<T>(T[] array, T element, int index)
        {
            if (index >= array.Length || index < 0)
                throw new ArgumentOutOfRangeException();


            T[] expandedArray = new T[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                if (i < index)
                    expandedArray[i] = array[i];
                else
                    expandedArray[i + 1] = array[i];
            }

            expandedArray[index] = element;

            return expandedArray;
        }

        /// <summary>
        /// Remove the first element of the array
        /// <para> return: modified Array </para> 
        /// </summary>

        public static T[] RemoveFirst<T>(T[] array)
        {
            if (array.Length < 1)
                throw new ArgumentException("The length of the array has to be greater than 0");

            T[] expandedArray = new T[array.Length - 1];

            for (int i = 1; i < array.Length; i++)
                expandedArray[i - 1] = array[i];

            return expandedArray;
        }

        /// <summary>
        /// Remove the last element of the array
        /// <para>´return: modified Array </para> 
        /// </summary>
        public static T[] RemoveLast<T>(T[] array)
        {
            if (array.Length < 1)
                throw new ArgumentException("The length of the array has to be greater than 0");

            T[] expandedArray = new T[array.Length - 1];

            for (int i = 1; i < array.Length - 1; i++)
                expandedArray[i] = array[i];

            return expandedArray;
        }

        /// <summary>
        /// Remove an element of the given index of the array
        /// <para> return: modified Array </para> 
        /// </summary>

        public static T[] RemoveAt<T>(T[] array, int index)
        {
            if (index >= array.Length || index < 0)
                throw new ArgumentOutOfRangeException();

            T[] expandedArray = new T[array.Length - 1];

            for (int i = 0; i < array.Length; i++)
            {
                if (i < index)
                    expandedArray[i] = array[i];
                else if (i > index)
                    expandedArray[i - 1] = array[i];
            }

            return expandedArray;
        }
    }
}