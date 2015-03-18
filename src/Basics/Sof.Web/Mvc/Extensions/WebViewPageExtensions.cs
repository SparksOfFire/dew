using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sof.Web.Mvc.Extensions
{
    public static class WebViewPageExtensions
    {
        public static HtmlString RequireJs(this WebViewPage page, string moduleFile)
        {
            var script = string.Format("<script src=\"{0}\" data-main=\"{1}\"></script>",
              page.Url.Content("~/scripts/require.js"), page.Url.Content(moduleFile));
            return new HtmlString(script);
        }
    }
}
