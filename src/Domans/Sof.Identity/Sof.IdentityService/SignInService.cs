using Microsoft.Owin;
using Microsoft.Owin.Security;
using Sof.Identity.Core;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Sof.Identity.Services
{
    /// <summary>
    ///  应用程序登录管理器。
    /// </summary>
    public class SignInService
    {
        public SignInStatus SignIn(string userName, string password, bool rememberMe = false, bool shouldLockout = false)
        {
            SignInStatus result;
            var userService = new UserService();
            var user = userService.FindByName(userName);
            if (user == null)
            {
                result = SignInStatus.Failure;  // 账户不存在
            }
            else if (user.IsLockedOut())
            {
                result = SignInStatus.LockedOut;    // 账户已锁定
            }
            else if (user.CheckPassword(password)) // 登录成功
            {
                return SignInStatus.Success;
                //result = this.SignInOrTwoFactor(user, rememberMe);
            }
            else if (shouldLockout) // 密码不正确
            {
                userService.AccessFailed(user.Id);
                if (user.IsLockedOut()) // 账户已锁定
                {
                    result = SignInStatus.LockedOut;
                    return result;
                }
            }
            result = SignInStatus.Failure;
            return result;
        }

        public SignInStatus SignIn(Models.User user, bool rememberMe = false, bool shouldLockout = false)
        {
            return SignIn(user.UserName, user.PasswordHash, rememberMe, shouldLockout);
        }
    }
}
