using Sof.Utilites;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;


namespace Sof.Extensions
{
    /// <summary>
    /// 字符串扩展方法
    /// </summary>
    public static class StringExtensions
    {
        private static Regex rxChinese = new Regex("^[\u4e00-\u9fa5]+$", RegexOptions.Compiled);
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
            return value.AsInt(0) ?? 0;
        }

        /// <summary>将字符串转换为整数，并指定一个默认值。</summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="defaultValue">如果 <paramref name="value" /> 为空或是一个无效的值则返回该值,。</param>
        /// <returns>转换后的值。</returns>
        public static int? AsInt(this string value, int? defaultValue)
        {
            int result;
            if (!int.TryParse(value, out result))
            {
                return defaultValue;
            }
            return result;
        }

        /// <summary>将字符串转换为整数。</summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static long AsLong(this string value)
        {
            return value.AsLong(0) ?? 0L;
        }

        /// <summary>将字符串转换为整数，并指定一个默认值。</summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="defaultValue">如果 <paramref name="value" /> 为空或是一个无效的值则返回该值,。</param>
        /// <returns>转换后的值。</returns>
        public static long? AsLong(this string value, long? defaultValue)
        {
            long result;
            if (!long.TryParse(value, out result))
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
            return value.AsDecimal(0).Value;
        }

        /// <summary>将字符串转换为 <see cref="T:System.Decimal" /> ，并指定一个默认值。</summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="defaultValue">如果 <paramref name="value" /> 为空或是一个无效的值则返回该值,。</param>
        /// <returns>转换后的值。</returns>
        public static decimal? AsDecimal(this string value, decimal? defaultValue)
        {
            decimal result;
            if (!decimal.TryParse(value, out result))
            {
                return defaultValue;
            }
            return result;
        }

        /// <summary>将字符串转换为 <see cref="T:System.Single" /> </summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static float AsFloat(this string value)
        {
            return value.AsFloat(0f).Value;
        }

        /// <summary>将字符串转换为 <see cref="T:System.Single" /> ，并指定一个默认值。</summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="defaultValue">如果 <paramref name="value" /> 为空或是一个无效的值则返回该值,。</param>
        /// <returns>转换后的值。</returns>
        public static float? AsFloat(this string value, float? defaultValue)
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
            return value.AsDateTime(default(DateTime)).Value;
        }

        /// <summary>将字符串转换为 <see cref="T:System.DateTime" /> ，并指定一个默认值。</summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="defaultValue">如果 <paramref name="value" /> 为空或是一个无效的值则返回该值,。</param>
        /// <returns>转换后的值。</returns>
        public static DateTime? AsDateTime(this string value, DateTime? defaultValue)
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
            return value.AsBool(false).Value;
        }

        /// <summary>将字符串转换为 <see cref="T:System.Boolean" />，并指定一个默认值。</summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="defaultValue">如果 <paramref name="value" /> 为空或是一个无效的值则返回该值,。</param>
        /// <returns>转换后的值。</returns>
        public static bool? AsBool(this string value, bool? defaultValue)
        {
            bool result;
            if (!bool.TryParse(value, out result))
            {
                return defaultValue;
            }
            return result;
        }

        /// <summary>
        /// 将字符串转为五笔码
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static string AsWuBiMa(this string value)
        {
            return InputCode.GetWuBiMa(value);
        }

        /// <summary>
        /// 将字符串转为拼音码
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static string AsPinYinMa(this string value)
        {
            return InputCode.GetFirstPinYin(value);
        }

        /// <summary>检查一个字符串是否可以转换为布尔值（真或假）型。</summary>
        /// <param name="value">检查字符串值。</param>
        /// <returns>true 如果 <paramref name="value" /> 可以转换为指定的类型; 否则, false.</returns>
        public static bool IsBool(this string value)
        {
            bool flag;
            return bool.TryParse(value, out flag);
        }

        /// <summary>检查一个字符串是否可以转换为整形。</summary>
        /// <param name="value">检查字符串值。</param>
        /// <returns>true 如果 <paramref name="value" /> 可以转换为指定的类型; 否则, false.</returns>
        public static bool IsInt(this string value)
        {
            int num;
            return int.TryParse(value, out num);
        }

        /// <summary>检查一个字符串是否可以转换为 <see cref="T:System.Decimal" /> 类型.</summary>
        /// <param name="value">检查字符串值。</param>
        /// <returns>true 如果 <paramref name="value" /> 可以转换为指定的类型; 否则, false.</returns>
        public static bool IsDecimal(this string value)
        {
            return value.Is<decimal>();
        }

        /// <summary>检查一个字符串是否可以转换为 <see cref="T:System.Single" /> 类型.</summary>
        /// <param name="value">检查字符串值。</param>
        /// <returns>true 如果 <paramref name="value" /> 可以转换为指定的类型; 否则, false.</returns>
        public static bool IsFloat(this string value)
        {
            float num;
            return float.TryParse(value, out num);
        }

        /// <summary>检查一个字符串是否可以转换为 <see cref="T:System.DateTime" /> 类型.</summary>
        /// <param name="value">检查字符串值。</param>
        /// <returns>true 如果 <paramref name="value" /> 可以转换为指定的类型; 否则, false.</returns>
        public static bool IsDateTime(this string value)
        {
            DateTime dateTime;
            return DateTime.TryParse(value, out dateTime);
        }

        /// <summary>
        /// 检查一个字符串是否由中文组成
        /// </summary>
        /// <param name="value">检查字符串值。</param>
        /// <returns>true 如果 <paramref name="value" /> 全是中文; 否则, false.</returns>
        public static bool IsChinese(this string value)
        {
            return rxChinese.IsMatch(value);
        }
    
    }
}
