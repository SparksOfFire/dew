using Sof.Core.Ioc;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Web;

namespace Sof.Dew.MvcApp
{
    public static class MefConfig
    {
        public static void RegisterCatalogs(ICollection<ComposablePartCatalog> catalogs)
        {
            //var builder = new System.ComponentModel.Composition.Registration.RegistrationBuilder();
            //builder.ForTypesDerivedFrom<Sof.Services.IService>().ExportInterfaces(i => i.Name != "IService");
            //builder.ForTypesDerivedFrom<Sof.Services.IStore>().ExportInterfaces(i => i.Name != "IStore");
            //var catalog = new System.ComponentModel.Composition.Hosting.DirectoryCatalog(Server.MapPath("~/bin"), "*.dll", builder);
            //catalogs.Add(catalog);
        }
    }
}