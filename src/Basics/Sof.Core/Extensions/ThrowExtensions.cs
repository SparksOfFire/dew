using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Extensions
{
    public static class ThrowExtensions
    {
        #region 异常检查
        public static void ThrowIfNull(this object argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

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

        public static void THrowIfOutOfRange(this IComparable argumentValue, string argumentName, object min, object max)
        {
            if (argumentValue.CompareTo(min) < 0 || argumentValue.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        #endregion
    }
}
