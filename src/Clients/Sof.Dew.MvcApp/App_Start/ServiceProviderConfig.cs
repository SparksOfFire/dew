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
            Sof.Core.ServiceFactory.ProviderName = typeof(Sof.Core.Ioc.MefServiceProvider).FullName;
            Sof.Core.ServiceFactory.ServiceProviders.Add(new Sof.Core.Ioc.MefServiceProvider());
        }
    }
}