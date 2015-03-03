using Sof.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Sof.Identity.Services
{
    public class UserService : UserService<long>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class UserService<TKey> : ServiceBase
    {
        internal const string IdentityProviderClaimType = "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider";
        internal const string IdentityProviderClaimValue = "ASP.NET Identity";
        internal const string SecurityStampClaimType = "AspNet.Identity.SecurityStamp";

        /// <summary>
        /// 登录失败
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Core.IdentityResult AccessFailed(TKey userId)
        {
            var user = this.FindById(userId);
            user.AccessFailedCount++;
            var ret = this.DbContext.SaveChanges();
            return ret > 0 ? Core.IdentityResult.Success : Core.IdentityResult.Failed();
        }

        public Core.IdentityResult Create(Models.User user, string password)
        {
            user.PasswordHash = Sof.Security.Encryption.MD5Encrypt(user.SecurityStamp + password);
            this.DbContext.Users.Add(user);
            var ret = this.DbContext.SaveChanges();
            return ret > 0 ? Core.IdentityResult.Success : Core.IdentityResult.Failed("创建用户失败！");
        }

        public Core.IdentityResult ChangePassword(TKey userId, string oldPassword, string newPassword)
        {
            var user = this.FindById(userId);
            user.ThrowIfNull("修改的用户不存在或已经删除！");
            var check = user.CheckPassword(oldPassword);
            if (check)
            {
                user.PasswordHash = new Core.PasswordHasher().HashPassword(newPassword);
                var ret = this.DbContext.SaveChanges();
                return ret > 0 ? Core.IdentityResult.Success : Core.IdentityResult.Failed("密码修改失败！");
            }
            else
            {
                return Core.IdentityResult.Failed("旧密码不正确！");
            }
        }

        /// <summary>
        /// 通过主键获取用户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public Models.User FindById(TKey userId)
        {
            return GetUser(u => u.Id.Equals(userId));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Models.User FindByName(string userName)
        {
            userName.ThrowIfNullOrEmpty("userName");
            return GetUser(u => u.UserName.ToUpper() == userName.ToUpper());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public virtual ClaimsIdentity GenerateUserIdentity(Core.IUser<TKey> user)
        {
            var claimsIdentity = new ClaimsIdentity(IdentityProviderClaimType);
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.UserName, ClaimValueTypes.String));
            claimsIdentity.AddClaim(new Claim(IdentityProviderClaimType, IdentityProviderClaimValue, ClaimValueTypes.String));
            claimsIdentity.AddClaim(new Claim(SecurityStampClaimType, user.SecurityStamp));
            var roles = this.GetRoles(user.Id);
            foreach (var name in roles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, name, ClaimValueTypes.String));
            }
            claimsIdentity.AddClaims(this.GetClaims(user.Id));
            return claimsIdentity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<Claim> GetClaims(TKey userId)
        {
            return this.DbContext.UserClaims
                .Where(c => c.UserId.Equals(userId))
                .Select(c => new Claim(c.ClaimType, c.ClaimValue))
                .ToList<Claim>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<Models.UserLogin> GetLogins(TKey userId)
        {
            return this.DbContext.UserLogins.Where(l => l.UserId.Equals(userId)).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IList<string> GetRoles(TKey userId)
        {
            var source =
                 from userRoles in this.DbContext.UserRoles
                 join roles in this.DbContext.Roles on userRoles.RoleId equals roles.Id
                 select roles.Name;
            return source.ToList();
        }

        private Models.User GetUser(Expression<Func<Models.User, bool>> filter)
        {
            return this.DbContext.Users.AsNoTracking()
                .Include(u => u.Roles)
                .Include(u => u.Claims)
                .Include(u => u.Logins)
                .FirstOrDefault(filter);
        }

        //public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        //{
        //    var db = context.Get<IdentityDbContext>();
        //    var manager = new UserManager(new UserStore<Models.User>(db));

        //    #region 配置用户名的验证逻辑
        //    manager.UserValidator = new UserValidator<Models.User>(manager)
        //    {
        //        AllowOnlyAlphanumericUserNames = false, // UserNames 只允许使用 [A-Za-z0-9]
        //        RequireUniqueEmail = false, // 获取或设置是否验证用户电子邮件是唯一的
        //    };
        //    #endregion

        //    #region 配置密码的验证逻辑

        //    manager.PasswordValidator = new PasswordValidator
        //    {
        //        RequiredLength = 4,
        //        RequireNonLetterOrDigit = false, //获取或设置密码是否需要一个非字母或数字字符。
        //        RequireDigit = false,                    // 获取或设置密码是否需要一个数字（0-9）。
        //        RequireLowercase = false,           // 获取或设置密码是否需要一个小写字母（a-z）。
        //        RequireUppercase = false,           // 获取或设置密码是否需要一个大写字母（A-Z）。
        //    };
        //    #endregion

        //    #region 配置用户锁定默认值

        //    manager.UserLockoutEnabledByDefault = true;
        //    manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
        //    manager.MaxFailedAccessAttemptsBeforeLockout = 5;
        //    #endregion

        //    // 注册双重身份验证提供程序。此应用程序使用手机和电子邮件作为接收用于验证用户的代码的一个步骤
        //    // 你可以编写自己的提供程序并将其插入到此处。
        //    manager.RegisterTwoFactorProvider("手机验证码", new Microsoft.AspNet.Identity.PhoneNumberTokenProvider<Models.User>
        //    {
        //        MessageFormat = "你的验证码是 {0}"
        //    });
        //    manager.RegisterTwoFactorProvider("邮件验证码", new Microsoft.AspNet.Identity.EmailTokenProvider<Models.User>
        //    {
        //        Subject = "安全代码",
        //        BodyFormat = "你的验证码是 {0}"
        //    });

        //    //manager.EmailService = new Sof.EmailService.IdentityEmailService();
        //    //manager.SmsService = new Sof.SmsService.IdentitySmsService();

        //    // 表示可用于对静态数据或数据流进行异步加密和解密的加密提供程序
        //    var dataProtectionProvider = options.DataProtectionProvider;
        //    if (dataProtectionProvider != null)
        //    {
        //        manager.UserTokenProvider =
        //            new DataProtectorTokenProvider<Models.User>(dataProtectionProvider.Create("ASP.NET Identity"));
        //    }
        //    return manager;
        //}

    }
}
