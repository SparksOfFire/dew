using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sof.Dew.MvcApp
{
    public static class ServiceProviderConfig
    {
        public static void Configure()
        {
            Sof.ServiceFactory.ProviderName = typeof(Sof.Ioc.MefServiceProvider).FullName;
            Sof.ServiceFactory.ServiceProviders.Add(new Sof.Ioc.MefServiceProvider());
        }
    }
}