using log4net;
using Sof.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Sof.Dew.MvcApp
{
    public static class LoggingConfig
    {
        public static void Configure()
        {
            Common.Logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}