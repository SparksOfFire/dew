using System;

namespace Sof.Extensions
{
    public static class ThrowExtensions
    {
        /// <summary>
        /// 如果值为 null 则引发 ArgumentNullException 异常
        /// </summary>
        /// <param name="argumentValue">参数值</param>
        /// <param name="argumentName">参数名称</param>
        /// <param name="message">异常提示信息</param>
        public static void ThrowIfNull(this object argumentValue, string argumentName, string message = null)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }

        /// <summary>
        /// 如果值为 null 或 空白 则引发 ArgumentException 异常
        /// </summary>
        /// <param name="argumentValue">参数值</param>
        /// <param name="argumentName">参数名称</param>
        public static void ThrowIfNullOrEmpty(this object argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
            if (string.IsNullOrEmpty(argumentName.ToString()))
            {
                throw new ArgumentException("提供的字符串参数不能为 null 或空字符串 (\"\")。", argumentName);
            }
        }

        /// <summary>
        /// 如果 值 小于 min 或 大于 max 则引发 ArgumentOutOfRangeException 异常
        /// </summary>
        /// <param name="argumentValue">参数值</param>
        /// <param name="argumentName">参数名称</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        public static void THrowIfOutOfRange(this IComparable argumentValue, string argumentName, object min, object max)
        {
            if (argumentValue.CompareTo(min) < 0 || argumentValue.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }
    }
}
