using System;
using System.Collections.Generic;
using System.Linq;


namespace LINQ_Collections
{
    public static class ArrayFunctions
    {
        public static IEnumerable<T> CollectionSort<T>(this IEnumerable<T> collection)
        {
            return collection.OrderBy(n => n);
        }

        public static IEnumerable<T> RemoveLast<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
            {
                return collection;
            }
            else
            {
                return RemoveAt(collection, collection.Count() - 1);
            }
        }

        public static IEnumerable<T> RemoveFirst<T>(this IEnumerable<T> collection)
        {
            return RemoveAt(collection, 0);
        }

        public static IEnumerable<T> RemoveAt<T>(this IEnumerable<T> collection, int index)
        {
            return collection.Take(index)
                .Concat(collection.Skip(index + 1));
        }

        public static IEnumerable<T> InsertFirst<T>(this IEnumerable<T> collection, T element)
        {
            return InsertAt(collection, element, 0);
        }

        public static IEnumerable<T> InsertLast<T>(this IEnumerable<T> collection, T element)
        {
            if (collection == null)
            {
                return InsertAt(collection, element, 0);
            }
            else
            {
                return InsertAt(collection, element, collection.Count());
            }
        }

        public static IEnumerable<T> InsertAt<T>(this IEnumerable<T> collection, T element, int index)
        {
            if((collection == null || collection.Count() < 1) && index == 0)
            {
                return element.SingleItemToEnumerable();
            }

            if(index < 0 || index > collection.Count())
            {
                return collection;
            }

            return collection.Take(index)
                .Concat(element.SingleItemToEnumerable())
                .Concat(collection.Skip(index));
        }

        public static IEnumerable<T> SingleItemToEnumerable<T>(this T element)
        {
            yield return element;
        }
    }
}
