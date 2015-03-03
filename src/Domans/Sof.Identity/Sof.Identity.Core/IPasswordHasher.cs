using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Identity.Core
{
    /// <summary>
    /// 密码混淆处理接口
    /// </summary>
    public interface IPasswordHasher
    {
        /// <summary>
        ///  返回混淆后的密码
        /// </summary>
        /// <param name="password">明文密码</param>
        /// <returns>混淆后的密码</returns>
        string HashPassword(string password);

        /// <summary>
        ///  密码验证
        /// </summary>
        /// <param name="hashedPassword">返回混淆后的密码</param>
        /// <param name="providedPassword">明文密码</param>
        /// <returns>密码验证结果</returns>
        /// <returns></returns>
        PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword);
    }
}
