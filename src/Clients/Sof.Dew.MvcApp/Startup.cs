using Microsoft.Owin;
using Owin;
using System.Web;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(Sof.Dew.MvcApp.Startup))]
namespace Sof.Dew.MvcApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IdentityService.Startup.ConfigureAuth(app);
           
        }
    }
}
