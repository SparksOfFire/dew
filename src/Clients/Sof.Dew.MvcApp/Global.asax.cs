using Sof.Core.Ioc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sof.Dew.MvcApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            LoggingConfig.RegisterLogger();
            MefConfig.RegisterCatalogs(Mef.Catalogs);
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ViewEngineConfig.RegisterEngines(ViewEngines.Engines);
        }
    }

}
