using Sof.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sof.Identity.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class User : Core.IUser, Data.IEntity
    {
        #region 属性

        /// <summary>
        /// 用户ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string PasswordHash { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SecurityStamp { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>

        public string PhoneNumber { get; set; }
        /// <summary>
        /// 手机号码确认
        /// </summary>
        public bool PhoneNumberConfirmed { get; set; }
        /// <summary>
        /// 账户被锁定
        /// </summary>

        public bool LockoutEnabled { get; set; }
        /// <summary>
        /// 账户锁定时间
        /// </summary>
        public DateTime? LockoutEndDateUtc { get; set; }
        /// <summary>
        /// 连续登录失败次数
        /// </summary>
        public int AccessFailedCount { get; set; }
        /// <summary>
        /// 二次登录验证
        /// </summary>
        public bool TwoFactorEnabled { get; set; }

        public virtual ICollection<UserRole> Roles { get; private set; }
        public virtual ICollection<UserClaim> Claims { get; private set; }
        public virtual ICollection<UserLogin> Logins { get; private set; }

        #endregion

        #region 方法

        /// <summary>
        /// 验证账户是否被锁定
        /// </summary>
        /// <returns></returns>
        public bool IsLockedOut()
        {
            bool result;
            if (!this.LockoutEnabled)
            {
                result = false;
            }
            else
            {
                result = this.LockoutEndDateUtc >= DateTimeOffset.UtcNow;
            }
            return result;
        }

        public bool CheckPassword(string password)
        {
            var hasher = Sof.ServiceFactory.GetService<Core.IPasswordHasher>();
            return hasher.VerifyHashedPassword(this.PasswordHash, password) != Core.PasswordVerificationResult.Failed;
        }

        #endregion
    }
}
