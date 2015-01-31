using System;
using System.Collections.Generic;

namespace Sof.Extensions
{
    public static class IEnumerableExtensions
    {
        public static string Join<T>(this IEnumerable<T> listValue, string separator = ",")
        {
            return string.Join(separator, listValue);
        }
    }
}
