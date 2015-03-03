using System;

namespace Sof.Identity.Core
{
    /// <summary>
    /// 密码验证结果
    /// </summary>
    public enum PasswordVerificationResult
    {
        /// <summary>
        /// 密码验证失败
        /// </summary>
        Failed,
        /// <summary>
        /// 密码验证成功
        /// </summary>
        Success,
        /// <summary>
        ///  验证成功，但需要修改密码
        /// </summary>
        SuccessRehashNeeded
    }
}
