using System.Linq;

namespace Homework2
{
    public static class ArrayExtension
    {
        public static T[] AddAt<T>(this T[] array, T item, int idx)
        {
            var firsthalf = array.Take(idx + 1);
            var secondhalf = array.Skip(idx + 1);

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
            var cleaned = array.RemoveAt(idx);

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
            array.Sort();
        }
    }
}