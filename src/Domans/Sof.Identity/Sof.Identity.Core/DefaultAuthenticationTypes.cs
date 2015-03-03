using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.IdentityService
{
    public static class DefaultAuthenticationTypes
    {
        /// <summary>
        /// UseSignInCookies 使用的主应用程序 Cookie 的默认值
        /// </summary>
        public const string ApplicationCookie = "ApplicationCookie";
        /// <summary>
        /// 由 UseSignInCookies 配置的 ExternalSignInAuthenticationType 使用的默认值
        /// </summary>
        public const string ExternalCookie = "ExternalCookie";
        /// <summary>
        /// UseOAuthBearerTokens 方法使用的默认值
        /// </summary>
        public const string ExternalBearer = "ExternalBearer";
        /// <summary>
        /// Default value for authentication type used for two factor partial sign in
        /// </summary>
        public const string TwoFactorCookie = "TwoFactorCookie";
        /// <summary>
        ///  Default value for authentication type used for two factor remember browser
        /// </summary>
        public const string TwoFactorRememberBrowserCookie = "TwoFactorRememberBrowser";
    }
}
