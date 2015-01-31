using Sof.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sof.Dew.MvcApp
{
    public static class ViewEngineConfig
    {
        public static void RegisterEngines(ViewEngineCollection engines)
        {
            engines.Clear();
            engines.Add(new CsRazorViewEngine());
        }
    }
}