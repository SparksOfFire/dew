﻿using Sof;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.Registration;
using System.Data.Entity;
using System.Web;

namespace Sof.Dew.MvcApp
{
    public static class MefConfig
    {
        public static void RegisterCatalogs(ICollection<ComposablePartCatalog> catalogs)
        {
            var builder = new RegistrationBuilder();
            builder.ForTypesDerivedFrom<IService>().Export().ExportInterfaces();
            builder.ForTypesDerivedFrom<DbContext>().Export().SetCreationPolicy(CreationPolicy.NonShared);
            var catalog = new DirectoryCatalog(HttpContext.Current.Server.MapPath("~/bin"), "Sof*.dll", builder);
            catalogs.Add(catalog);
        }

        //public static void RegisterMef()
        //{
        //    var builder = RegisterExports();
        //    var resolver = DependencyResolver.Current;
        //    var newResolver = new MefDependencyResolver(builder, resolver);
        //    DependencyResolver.SetResolver(newResolver);
        //}

        //private static AttributedModelProvider RegisterExports()
        //{
        //    var builder = new ConventionBuilder();
        //    return builder;
        //}
    }
}