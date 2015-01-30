using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Sof.Dew.MvcApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var builder = new System.ComponentModel.Composition.Registration.RegistrationBuilder();
            //builder.ForTypesDerivedFrom<Sof.Services.IService>().ExportInterfaces(i => i.Name != "IService");
            //builder.ForTypesDerivedFrom<Sof.Services.IStore>().ExportInterfaces(i => i.Name != "IStore");
            //var catalog = new System.ComponentModel.Composition.Hosting.DirectoryCatalog(Server.MapPath("~/bin"), "*.dll", builder);
            //var container = new System.ComponentModel.Composition.Hosting.CompositionContainer(catalog);
            //var service = container.GetExportedValue<Sof.Services.DoctorService>();
            //var s = new Sof.Services.DoctorService();
            //container.SatisfyImportsOnce(s);
            //var ret = service.Get();
        }
    }
}
