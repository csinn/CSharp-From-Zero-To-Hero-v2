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
        /// Insert an element at the start of the array
        /// <para> return: modified Array </para> 
        /// </summary>

        public static T[] AppendToStart<T>(T[] array, T element)
        {
            T[] modifiedArray = InsertAt<T>(array, element, 0);

            return modifiedArray;
        }

        /// <summary>
        /// Remove the first element of the array
        /// <para> return: modified Array </para> 
        /// </summary>

        public static T[] RemoveFirst<T>(T[] array)
        {
            T[] modifiedArray = RemoveAt<T>(array, 0);

            return modifiedArray;
        }

        /// <summary>
        /// Remove the last element of the array
        /// <para>´return: modified Array </para> 
        /// </summary>
        public static T[] RemoveLast<T>(T[] array)
        {
            T[] modifiedArray = RemoveAt<T>(array, array.Length - 1);

            return modifiedArray;
        }

        /// <summary>
        /// Insert an element at the given position in the array
        /// <para> return: modified Array </para> 
        /// </summary>

        public static T[] InsertAt<T>(T[] array, T element, int index)
        {
            if (index >= array.Length || index < 0)
                throw new ArgumentOutOfRangeException();


            T[] modifiedArray = new T[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                if (i < index)
                    modifiedArray[i] = array[i];
                else
                    modifiedArray[i + 1] = array[i];
            }

            modifiedArray[index] = element;

            return modifiedArray;
        }

        /// <summary>
        /// Remove an element of the given index of the array
        /// <para> return: modified Array </para> 
        /// </summary>

        public static T[] RemoveAt<T>(T[] array, int index)
        {
            if (index >= array.Length || index < 0 || array == null)
                throw new ArgumentOutOfRangeException();

            T[] modifiedArray = new T[array.Length - 1];

            for (int i = 0; i < array.Length; i++)
            {
                if (i < index)
                    modifiedArray[i] = array[i];
                else if (i > index)
                    modifiedArray[i - 1] = array[i];
            }

            return modifiedArray;
        }

        private static int[] SwapElements(int[] array, int firstIndex, int secondIndex)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;

            return array;
        }
    }
}