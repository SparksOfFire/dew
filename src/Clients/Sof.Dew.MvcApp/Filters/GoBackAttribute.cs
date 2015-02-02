using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sof.Dew.MvcApp.Filters
{
    public class GoBackAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewBag.BackUrl == null)
            {
                filterContext.Controller.ViewBag.BackUrl = "javascript:window.history.go(-1);";
            }
            base.OnResultExecuting(filterContext);
        }
    }
}