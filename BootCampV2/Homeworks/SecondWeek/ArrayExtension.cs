using System;

namespace BootCampV2
{
    public class ArrayExtension
    {
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

        public static int[] SwapElements(int[] array, int firstIndex, int secondIndex)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;

            return array;
        }

        public static T[] AppendToStart<T>(T[] array, T element)
        {
            T[] expandedArray = new T[array.Length + 1];

            for(int i = 0; i < array.Length; i++)
            {
                expandedArray[i + 1] = array[i];
            }

            expandedArray[0] = element;

            return expandedArray;
        }

        public static T[] InsertAt<T>(T[] array, T element, int index)
        {
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

        public static T[] RemoveFirst<T>(T[] array)
        {
            T[] expandedArray = new T[array.Length - 1];

            for (int i = 1; i < array.Length; i++)
                expandedArray[i - 1] = array[i];

            return expandedArray;
        }

        public static T[] RemoveLast<T>(T[] array)
        {
            T[] expandedArray = new T[array.Length - 1];

            for (int i = 1; i < array.Length - 1; i++)
                expandedArray[i] = array[i];

            return expandedArray;
        }

        public static T[] RemoveAt<T>(T[] array, int index)
        {
            T[] expandedArray = new T[array.Length - 1];

            for (int i = 0; i < array.Length; i++)
            {
                if (i < index)
                    expandedArray[i] = array[i];
                else if(i > index )
                    expandedArray[i - 1] = array[i];
            }

            return expandedArray;
        }
    }
}