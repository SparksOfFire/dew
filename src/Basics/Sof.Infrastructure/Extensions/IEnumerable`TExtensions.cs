using System;
using System.Collections.Generic;

namespace Sof.Extensions
{
    /// <summary>
    /// 集合类型扩展方法
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// 返回按指定字符分隔的字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listValue"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> listValue, string separator = ",")
        {
            return string.Join(separator, listValue);
        }
    }
}
