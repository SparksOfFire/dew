using Sof.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sof.Dew.MvcApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DatabaseConfig.Initializes();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            MefConfig.RegisterCatalogs(Mef.Catalogs);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ViewEngineConfig.RegisterEngines(ViewEngines.Engines);
        }
    }

}
