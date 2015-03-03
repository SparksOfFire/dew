using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Identity.Core
{
    /// <summary>
    ///  密码混淆处理实现类
    /// </summary>
    public class PasswordHasher : IPasswordHasher
    {
        /// <summary>
        ///  返回混淆后的密码
        /// </summary>
        /// <param name="password">明文密码</param>
        /// <returns>混淆后的密码</returns>
        public virtual string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        /// <summary>
        ///  密码验证
        /// </summary>
        /// <param name="hashedPassword">混淆后的密码</param>
        /// <param name="providedPassword">明文密码</param>
        /// <returns>密码验证结果</returns>
        public virtual PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (Crypto.VerifyHashedPassword(hashedPassword, providedPassword))
            {
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;
        }
    }
}
