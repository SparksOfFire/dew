using Sof.Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Sof.Identity.Core;

namespace Sof.Dew.MvcApp.Controllers
{
    [Authorize]
    public partial class AccountController : Controller
    {
        private UserService _userService;
        private SignInService _signInService;

        public AccountController()
        {
        }

        public UserService UserManager
        {
            get
            {
                return _userService ?? (_userService =Sof.ServiceFactory.GetService<UserService>());
            }
        }
        public SignInService SignInManager
        {
            get
            {
                return _signInService ?? (_signInService = Sof.ServiceFactory.GetService<SignInService>());
            }
        }

        // GET: User/Account
        public ActionResult Index()
        {
            return View();
        }


        #region Helper
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[AppConfig.XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

        #endregion
    }
}