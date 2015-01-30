using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.WebPages;

namespace Sof.Dew.MvcApp
{
    public class AppConfig
    {
        /// <summary>
        /// 用于在添加外部登录名时提供 XSRF 保护
        /// </summary>
        public const string XsrfKey = "XsrfId";

        /// <summary>
        /// 是否启用登录锁定
        /// </summary>
        public static bool LockoutEnabled = ConfigurationManager.AppSettings["LockoutEnabled"].AsBool(false);
    }
}