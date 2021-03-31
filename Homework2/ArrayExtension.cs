using System.Linq;

namespace Homework2
{
    public static class ArrayExtension
    {
        public static T[] AddAt<T>(this T[] array, T item, int idx)
        {
            int newSize = array.Length + 1;

            T[] output = new T[newSize];

            for (int i = 0; i < newSize; i++)
            {
                if (i == idx)
                {
                    output[i] = item;

                    for (int j = idx; j < array.Length; j++)
                    {
                        i++;
                        output[i] = array[j];
                    }

                    break;
                }

                output[i] = array[i];
            }

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
            int newSize = array.Length - 1;

            T[] output = new T[newSize];

            for (int i = 0; i < newSize; i++)
            {
                if (i == idx)
                {
                    for (int j = idx + 1; j < newSize; j++)
                    {
                        output[i] = array[j];
                        i++;
                    }

                    break;
                }

                output[i] = array[i];
            }

            return output;
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
            //var arraycopy = new T[array.Length];
            //array.CopyTo(arraycopy, 0);

            var arraycopy = array.ToList();

            for (int i = 0; i < array.Length; i++)
            {
                var currentmin = arraycopy.Min();

                array[i] = currentmin;

                arraycopy.Remove(currentmin);
            }
        }
    }
}