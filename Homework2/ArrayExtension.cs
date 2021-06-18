using System.Collections.Generic;
using System.Linq;

namespace Homework2
{
    public static class ArrayExtension
    {
        public static T[] AddAt<T>(this T[] array, T item, int idx)
        {
            var firsthalf = array.Take(idx );
            var secondhalf = array.Skip(idx );

            var firsthalfplus = firsthalf.Append(item);
            var output = firsthalfplus.Concat(secondhalf).ToArray();

            return output;
        }

        public static T[] AddAtBeginning<T>(this T[] array, T item)
        {
            return array.AddAt(item, 0);
        }

        public static T[] AddAtEnd<T>(this T[] array, T item)
        {
            return array.AddAt(item, array.Length);
        }

        public static T[] RemoveAt<T>(this T[] array, int idx)
        {
            var element = array.ElementAt(idx);
            var cleaned = array.Except(new List<T>() { element });

            return cleaned.ToArray();
        }

        public static T[] RemoveAtBeginning<T>(this T[] array)
        {
            return array.RemoveAt(0);
        }

        public static T[] RemoveAtEnd<T>(this T[] array)
        {
            return array.RemoveAt(array.Length - 1);
        }

        public static void Sort<T>(this T[] array)
        {
            var sortedarray = array.OrderBy(t => t).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = sortedarray[i];
            }
        }
    }
}