using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingListApi.Extensions
{
    public static class EnumerableExtension
    {
        public static string ToStringMany<T>(this IEnumerable<T> items)
        {
            if(items == null || !items.Any()) return "";

                // item1, item2
            return string.Join(
                ", ",
                items.Select(item => item.ToString())
            ) + ".";
        }
    }
}
