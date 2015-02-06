using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sof.Web.Mvc.Filters
{
    public class DefaultErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            base.OnException(filterContext);
        }
    }
}
