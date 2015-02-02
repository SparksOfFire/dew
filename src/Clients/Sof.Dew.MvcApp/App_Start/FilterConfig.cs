using Sof.Web.Mvc.Filters;
using System.Web;
using System.Web.Mvc;

namespace Sof.Dew.MvcApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new DefaultErrorAttribute());
            filters.Add(new Filters.GoBackAttribute());
        }
    }

}
