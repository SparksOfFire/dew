using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Identity.Core
{
    /// <summary>
    /// 登录状态
    /// </summary>
    public enum SignInStatus
    {
        /// <summary>
        /// 登录失败
        /// </summary>
        Failure,
        /// <summary>
        /// 登录成功
        /// </summary>
        Success,
        /// <summary>
        /// 账号被锁
        /// </summary>
        LockedOut,
        /// <summary>
        /// 需要验证码
        /// </summary>
        RequiresVerification
    }
}
