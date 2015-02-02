using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sof.Web.Mvc.Extensions.Bootstrap
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString BsFromGroup(this HtmlHelper html, Func<MvcHtmlString> control)
        {
            TagBuilder tagBuilder = new TagBuilder("div");
            tagBuilder.InnerHtml = control().ToString();
            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.EndTag));
        }
    }
}
