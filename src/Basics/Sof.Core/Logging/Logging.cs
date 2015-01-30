using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common
{
    public static class Logging
    {
        static ILog log;
        /// <summary>
        /// 构造函数
        /// </summary>
        static Logging()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                log = log4net.LogManager.GetCurrentLoggers().FirstOrDefault();
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.Write(ex.StackTrace);
            }
        }

        #region Debug 调试日志

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(object message)
        {
            if (log != null) log.Debug(message);
        }

        public static void Debug(object message, Exception exception)
        {
            if (log != null) log.Debug(message, exception);
        }

        public static void DebugFormat(string format, object arg0)
        {
            if (log != null) log.DebugFormat(format, arg0);
        }

        public static void DebugFormat(string format, params object[] args)
        {
            if (log != null) log.DebugFormat(format, args);
        }

        public static void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log != null) log.DebugFormat(provider, format, args);
        }

        public static void DebugFormat(string format, object arg0, object arg1)
        {
            if (log != null) log.DebugFormat(format, arg0, arg1);
        }

        public static void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log != null) log.DebugFormat(format, arg0, arg1, arg2);
        }

        #endregion

        #region Error 错误日志

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message"></param>
        public static void Error(object message)
        {
            if (log != null) log.Error(message);
        }

        public static void Error(object message, Exception exception)
        {
            if (log != null) log.Error(message, exception);
        }

        public static void ErrorFormat(string format, object arg0)
        {
            if (log != null) log.ErrorFormat(format, arg0);
        }

        public static void ErrorFormat(string format, params object[] args)
        {
            if (log != null) log.ErrorFormat(format, args);
        }

        public static void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log != null) log.ErrorFormat(provider, format, args);
        }

        public static void ErrorFormat(string format, object arg0, object arg1)
        {
            if (log != null) log.ErrorFormat(format, arg0, arg1);
        }

        public static void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log != null) log.ErrorFormat(format, arg0, arg1, arg2);
        }

        #endregion

        #region Fatal 致命的,毁灭性的日志

        /// <summary>
        /// 致命的,毁灭性的日志
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(object message)
        {
            if (log != null) log.Fatal(message);
        }

        public static void Fatal(object message, Exception exception)
        {
            if (log != null) log.Fatal(message, exception);
        }

        public static void FatalFormat(string format, object arg0)
        {
            if (log != null) log.FatalFormat(format, arg0);
        }

        public static void FatalFormat(string format, params object[] args)
        {
            if (log != null) log.FatalFormat(format, args);
        }

        public static void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log != null) log.FatalFormat(provider, format, args);
        }

        public static void FatalFormat(string format, object arg0, object arg1)
        {
            if (log != null) log.FatalFormat(format, arg0, arg1);
        }

        public static void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log != null) log.FatalFormat(format, arg0, arg1, arg2);
        }

        #endregion

        #region Info 信息日志

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(object message)
        {
            if (log != null) log.Info(message);
        }

        public static void Info(object message, Exception exception)
        {
            if (log != null) log.Info(message, exception);
        }

        public static void InfoFormat(string format, object arg0)
        {
            if (log != null) log.InfoFormat(format, arg0);
        }

        public static void InfoFormat(string format, params object[] args)
        {
            if (log != null) log.InfoFormat(format, args);
        }

        public static void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log != null) log.InfoFormat(provider, format, args);
        }

        public static void InfoFormat(string format, object arg0, object arg1)
        {
            if (log != null) log.InfoFormat(format, arg0, arg1);
        }

        public static void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log != null) log.InfoFormat(format, arg0, arg1, arg2);
        }

        #endregion

        #region Warning 警告,注意,通知日志

        /// <summary>
        /// 警告,注意,通知日志
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(object message)
        {
            if (log != null) log.Warn(message);
        }

        public static void Warn(object message, Exception exception)
        {
            if (log != null) log.Warn(message, exception);
        }

        public static void WarnFormat(string format, object arg0)
        {
            if (log != null) log.WarnFormat(format, arg0);
        }

        public static void WarnFormat(string format, params object[] args)
        {
            if (log != null) log.WarnFormat(format, args);
        }

        public static void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log != null) log.WarnFormat(provider, format, args);
        }

        public static void WarnFormat(string format, object arg0, object arg1)
        {
            if (log != null) log.WarnFormat(format, arg0, arg1);
        }

        public static void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log != null) log.WarnFormat(format, arg0, arg1, arg2);
        }

        #endregion
    }
}
