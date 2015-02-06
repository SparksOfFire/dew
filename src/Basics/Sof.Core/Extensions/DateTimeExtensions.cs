using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetAge(this DateTime birthDate)
        {
            return birthDate.GetAge(DateTime.Today);
        }
        public static DateTime GetAge(this DateTime birthDate, DateTime whenDate)
        {
            if (whenDate < birthDate)
            {
                throw new Exception("年龄计算日期不能小于出生日期！");
            }
            int year = 0;
            int month = 0;
            int day = 0;
            // 出生月总天数
            var birthMonthDays = DateTime.DaysInMonth(birthDate.Year, birthDate.Month);
            day = whenDate.Day - birthDate.Day;
            if (day < 0)
            {
                // 判断出生日期和计算日期是不是都是月份的最后一天
                if (birthDate.Day == birthMonthDays && whenDate.Day == DateTime.DaysInMonth(whenDate.Year, whenDate.Month))
                {
                    // 出生月总天数大于当前月总天数的月底做满月处理,
                    // 如: 2000-03-31 到 2000-04-30 做为满月，5月份则要31号才做为满月
                    day = 0;
                }
                else // 天数不足(计算年龄日小于出生日)借月
                {
                    month -= 1;
                    var whenDatePrevMonth = whenDate.AddMonths(-1);// 当前日期上月日期
                    var prevMonthDays = DateTime.DaysInMonth(whenDatePrevMonth.Year, whenDatePrevMonth.Month);
                    // 如果借过来的月的总天数小于出生月的总天数，则以出生月的总在数为准
                    // 如:  2013-01-20 到 2013-03-10 , 此时借的是2月份, 小于出生月1月份的总天数,则天数为 10-20+31=21天
                    day += Math.Max(prevMonthDays, birthMonthDays);
                }
            }
            month += whenDate.Month - birthDate.Month;
            year = whenDate.Year - birthDate.Year;
            if (month < 0) // 月数不足借年
            {
                year -= 1;
                month += 12;
            }
            return new DateTime(year, month, day);
        }


        /// <summary>
        /// 将日期转换为指定格式的字符串,如果日期为 null, 则返回string.Empty
        /// </summary>
        /// <param name="dt">日期</param>
        /// <param name="format">格式化字符串</param>
        /// <returns></returns>
        public static string ToString(this DateTime? dt, string format)
        {
            if (dt.HasValue) return dt.Value.ToString(format);
            else return string.Empty;
        }
        /// <summary>
        /// 将日期转换为 yyyy-MM-dd 格式的字符串
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public static string ToDateString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 将日期转换为 yyyy-MM-dd HH:mm:ss 格式的字符串
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 将日期转换为 yyyy-MM-dd 格式的字符串
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public static string ToDateString(this DateTime? dt)
        {
            return dt.HasValue ? dt.Value.ToString("yyyy-MM-dd") : null;
        }
        /// <summary>
        /// 将日期转换为 yyyy-MM-dd  HH:mm:ss格式的字符串
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime? dt)
        {
            return dt.HasValue ? dt.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
        }
    }
}
