using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Sof.IdentityService.Services
{
    // 配置要在此应用程序中使用的应用程序登录管理器。
    public class SignInManager : SignInManager<Models.User, string>
    {
        public SignInManager(UserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public async Task<SignInStatus> SignInAsync(
            string loginName, string password, bool isPersistent, bool shouldLockout,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var user = await ((UserManager)UserManager).FindByNameAsync(loginName);
            if (user == null)
            {
                return SignInStatus.Failure;
            }
            return SignInStatus.Success;
        }

        public static SignInManager Create(IdentityFactoryOptions<SignInManager> options, IOwinContext context)
        {
            return new SignInManager(context.GetUserManager<UserManager>(), context.Authentication);
        }
    }
}
