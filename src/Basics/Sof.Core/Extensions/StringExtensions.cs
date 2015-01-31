using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Sof.Extensions
{
    public static class StringExtensions
    {
        /// <summary>检查字符串的值是否为null或空。</summary>
        /// <param name="value">检查字符串的值.</param>
        /// <returns>true  如果 <paramref name="value" />为null或空字符串; 否则, false.</returns>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>将字符串转换为整数。</summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static int AsInt(this string value)
        {
            return value.AsInt(0);
        }

        /// <summary>将字符串转换为整数，并指定一个默认值。</summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="defaultValue">如果 <paramref name="value" /> 为空或是一个无效的值则返回该值,。</param>
        /// <returns>转换后的值。</returns>
        public static int AsInt(this string value, int defaultValue)
        {
            int result;
            if (!int.TryParse(value, out result))
            {
                return defaultValue;
            }
            return result;
        }

        /// <summary>将字符串转换为<see cref="T:System.Decimal" /></summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static decimal AsDecimal(this string value)
        {
            return value.As<decimal>();
        }

        /// <summary>将字符串转换为 <see cref="T:System.Decimal" /> ，并指定一个默认值。</summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="defaultValue">如果 <paramref name="value" /> 为空或是一个无效的值则返回该值,。</param>
        /// <returns>转换后的值。</returns>
        public static decimal AsDecimal(this string value, decimal defaultValue)
        {
            return value.As(defaultValue);
        }

        /// <summary>将字符串转换为 <see cref="T:System.Single" /> </summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static float AsFloat(this string value)
        {
            return value.AsFloat(0f);
        }

        /// <summary>将字符串转换为 <see cref="T:System.Single" /> ，并指定一个默认值。</summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="defaultValue">如果 <paramref name="value" /> 为空或是一个无效的值则返回该值,。</param>
        /// <returns>转换后的值。</returns>
        public static float AsFloat(this string value, float defaultValue)
        {
            float result;
            if (!float.TryParse(value, out result))
            {
                return defaultValue;
            }
            return result;
        }

        /// <summary>将字符串转换为 <see cref="T:System.DateTime" /></summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static DateTime AsDateTime(this string value)
        {
            return value.AsDateTime(default(DateTime));
        }

        /// <summary>将字符串转换为 <see cref="T:System.DateTime" /> ，并指定一个默认值。</summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="defaultValue">如果 <paramref name="value" /> 为空或是一个无效的值则返回该值,。</param>
        /// <returns>转换后的值。</returns>
        public static DateTime AsDateTime(this string value, DateTime defaultValue)
        {
            DateTime result;
            if (!DateTime.TryParse(value, out result))
            {
                return defaultValue;
            }
            return result;
        }

        /// <summary>将字符串转换为 <see cref="T:System.Boolean" /></summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static bool AsBool(this string value)
        {
            return value.AsBool(false);
        }

        /// <summary>将字符串转换为 <see cref="T:System.Boolean" />，并指定一个默认值。</summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="defaultValue">如果 <paramref name="value" /> 为空或是一个无效的值则返回该值,。</param>
        /// <returns>转换后的值。</returns>
        public static bool AsBool(this string value, bool defaultValue)
        {
            bool result;
            if (!bool.TryParse(value, out result))
            {
                return defaultValue;
            }
            return result;
        }

        /// <summary>检查一个字符串是否可以转换为布尔值（真或假）型。</summary>
        /// <returns>true 如果 <paramref name="value" /> 可以转换为指定的类型; 否则, false.</returns>
        /// <param name="value">检查字符串值。</param>
        public static bool IsBool(this string value)
        {
            bool flag;
            return bool.TryParse(value, out flag);
        }

        /// <summary>检查一个字符串是否可以转换为整形。</summary>
        /// <returns>true 如果 <paramref name="value" /> 可以转换为指定的类型; 否则, false.</returns>
        /// <param name="value">检查字符串值。</param>
        public static bool IsInt(this string value)
        {
            int num;
            return int.TryParse(value, out num);
        }

        /// <summary>检查一个字符串是否可以转换为 <see cref="T:System.Decimal" /> 类型.</summary>
        /// <returns>true 如果 <paramref name="value" /> 可以转换为指定的类型; 否则, false.</returns>
        /// <param name="value">检查字符串值。</param>
        public static bool IsDecimal(this string value)
        {
            return value.Is<decimal>();
        }

        /// <summary>检查一个字符串是否可以转换为 <see cref="T:System.Single" /> 类型.</summary>
        /// <returns>true 如果 <paramref name="value" /> 可以转换为指定的类型; 否则, false.</returns>
        /// <param name="value">检查字符串值。</param>
        public static bool IsFloat(this string value)
        {
            float num;
            return float.TryParse(value, out num);
        }

        /// <summary>检查一个字符串是否可以转换为 <see cref="T:System.DateTime" /> 类型.</summary>
        /// <returns>true 如果 <paramref name="value" /> 可以转换为指定的类型; 否则, false.</returns>
        /// <param name="value">检查字符串值。</param>
        public static bool IsDateTime(this string value)
        {
            DateTime dateTime;
            return DateTime.TryParse(value, out dateTime);
        }
    }
}
