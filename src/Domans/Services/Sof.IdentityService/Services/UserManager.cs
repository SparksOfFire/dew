using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Sof.IdentityService.Services
{
    // 配置此应用程序中使用的应用程序用户管理器。
    // UserManager 在 ASP.NET Identity 中定义，并由此应用程序使用。
    public class UserManager : Microsoft.AspNet.Identity.UserManager<Models.User>
    {
        protected IUserStore<Models.User> _store;
        public UserManager(IUserStore<Models.User> store)
            : base(store)
        {
            this._store = store;
        }

        public async Task<Models.User> FindByLoginName(string loginName)
        {
            return await this.Users.FirstOrDefaultAsync(u => u.UserName == loginName || u.PhoneNumber == loginName);
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var db = context.Get<IdentityDbContext>();
            var manager = new UserManager(new UserStore<Models.User>(db));

            #region 配置用户名的验证逻辑
            manager.UserValidator = new UserValidator<Models.User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false, // UserNames 只允许使用 [A-Za-z0-9]
                RequireUniqueEmail = false, // 获取或设置是否验证用户电子邮件是唯一的
            };
            #endregion

            #region 配置密码的验证逻辑

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireNonLetterOrDigit = false, //获取或设置密码是否需要一个非字母或数字字符。
                RequireDigit = false,                    // 获取或设置密码是否需要一个数字（0-9）。
                RequireLowercase = false,           // 获取或设置密码是否需要一个小写字母（a-z）。
                RequireUppercase = false,           // 获取或设置密码是否需要一个大写字母（A-Z）。
            };
            #endregion

            #region 配置用户锁定默认值

            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            #endregion

            // 注册双重身份验证提供程序。此应用程序使用手机和电子邮件作为接收用于验证用户的代码的一个步骤
            // 你可以编写自己的提供程序并将其插入到此处。
            manager.RegisterTwoFactorProvider("手机验证码", new Microsoft.AspNet.Identity.PhoneNumberTokenProvider<Models.User>
            {
                MessageFormat = "你的验证码是 {0}"
            });
            manager.RegisterTwoFactorProvider("邮件验证码", new Microsoft.AspNet.Identity.EmailTokenProvider<Models.User>
            {
                Subject = "安全代码",
                BodyFormat = "你的验证码是 {0}"
            });

            //manager.EmailService = new Sof.EmailService.IdentityEmailService();
            //manager.SmsService = new Sof.SmsService.IdentitySmsService();

            // 表示可用于对静态数据或数据流进行异步加密和解密的加密提供程序
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<Models.User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
