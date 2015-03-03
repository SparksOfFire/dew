using Sof.Identity.Services;
using Microsoft.Owin.Security;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Sof.Identity.Core;
using Sof.Extensions;

namespace Sof.Dew.MvcApp.Areas.User.Controllers
{
    [Authorize]
    public partial class ManageController : Controller
    {
        private UserService _userService;
        public UserService UserManager
        {
            get
            {
                return _userService ?? (_userService = Sof.ServiceFactory.GetService<UserService>());
            }
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "已更改你的密码。"
                : message == ManageMessageId.SetPasswordSuccess ? "已设置你的密码。"
                : message == ManageMessageId.SetTwoFactorSuccess ? "已设置你的双重身份验证提供程序。"
                : message == ManageMessageId.Error ? "出现错误。"
                : message == ManageMessageId.AddPhoneSuccess ? "已添加你的电话号码。"
                : message == ManageMessageId.RemovePhoneSuccess ? "已删除你的电话号码。"
                : "";

            var user = UserManager.FindById(User.Identity.GetUserId().AsLong());
            var model = new Models.IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = user.PhoneNumber,
                TwoFactor = user.TwoFactorEnabled,
                Logins = UserManager.GetLogins(user.Id),
                //BrowserRemembered = AuthenticationManager.TwoFactorBrowserRemembered(user.Id)
            };
            return View(model);
        }

        //
        // GET: /Manage/AddPhoneNumber
        public ActionResult AddPhoneNumber()
        {
            return View();
        }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(Models.AddPhoneNumberViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            //// 生成令牌并发送该令牌
            //var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
            //if (UserManager.SmsService != null)
            //{
            //    var message = new IdentityMessage
            //    {
            //        Destination = model.Number,
            //        Body = "你的安全代码是: " + code
            //    };
            //    await UserManager.SmsService.SendAsync(message);
            //}
            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        }

        //
        // GET: /Manage/VerifyPhoneNumber
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            //var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
            // 通过 SMS 提供程序发送短信以验证电话号码
            return phoneNumber == null ? View("Error") : View(new Models.VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(Models.VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //var result = await UserManager.ChangePhoneNumberAsync(User.Identity.GetUserId(), model.PhoneNumber, model.Code);
            //if (result.Succeeded)
            //{
            //    var user = await UserManager.FindById(User.Identity.GetUserId());
            //    if (user != null)
            //    {
            //        await SignInAsync(user, isPersistent: false);
            //    }
            //    return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            //}
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            ModelState.AddModelError("", "无法验证电话号码");
            return View(model);
        }

        //
        // GET: /Manage/RemovePhoneNumber
        public async Task<ActionResult> RemovePhoneNumber()
        {
            //var result = await UserManager.SetPhoneNumbe(User.Identity.GetUserId(), null);
            //if (!result.Succeeded)
            //{
            //    return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            //}
            //var user = await UserManager.FindById(User.Identity.GetUserId());
            //if (user != null)
            //{
            //    await SignInAsync(user, isPersistent: false);
            //}
            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(Models.ChangePasswordViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            //var result = UserManager.ChangePassword(User.Identity.GetUserId().AsLong(), model.OldPassword, model.NewPassword);
            //if (result.Succeeded)
            //{
            //    var user = await UserManager.FindById(User.Identity.GetUserId());
            //    if (user != null)
            //    {
            //        await SignInAsync(user, isPersistent: false);
            //    }
            //    return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            //}
            //AddErrors(result);
            return View(model);
        }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetPassword(Models.SetPasswordViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var result = UserManager.AddPassword(User.Identity.GetUserId(), model.NewPassword);
            //    if (result.Succeeded)
            //    {
            //        var user = UserManager.FindById(User.Identity.GetUserId().AsLong());
            //        if (user != null)
            //        {
            //            SignIn(user);
            //        }
            //        return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
            //    }
            //    AddErrors(result);
            //}

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }

        //
        // GET: /Manage/ManageLogins
        public ActionResult ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "已删除外部登录名。"
                : message == ManageMessageId.Error ? "出现错误。"
                : "";
            var user = UserManager.FindById(User.Identity.GetUserId().AsLong());
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = UserManager.GetLogins(User.Identity.GetUserId().AsLong());
            //var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new Models.ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                //OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LinkLogin(string provider)
        //{
        //    // 请求重定向至外部登录提供程序，以链接当前用户的登录名
        //    return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        //}

        //
        // GET: /Manage/LinkLoginCallback
        //public async Task<ActionResult> LinkLoginCallback()
        //{
        //    var loginInfo = await AuthenticationManager.GetExternalLoginInfo(AppConfig.XsrfKey, User.Identity.GetUserId());
        //    if (loginInfo == null)
        //    {
        //        return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        //    }
        //    var result = await UserManager.AddLogin(User.Identity.GetUserId(), loginInfo.Login);
        //    return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        //}

        #region 帮助程序

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void SignInAsync(Identity.Models.User user, bool isPersistent)
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            //AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId<long>());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }
        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId<long>());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        #endregion
    }
}