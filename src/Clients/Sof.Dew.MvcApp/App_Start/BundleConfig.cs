using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Optimization;

namespace Sof.Dew.MvcApp
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                "~/scripts/common.js"));

            bundles.Add(new ScriptBundle("~/bundles/ltie9").Include(
                "~/scripts/html5shiv.js",
                "~/scripts/respond.js"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/fullpage").Include("~/scripts/fullpage.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/content/css").Include(
                      "~/content/bootstrap.css",
                      "~/content/site.css"));

            // 将 EnableOptimizations 设为 false 以进行调试。有关详细信息，
            // 请访问 http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = !((CompilationSection)ConfigurationManager.GetSection("system.web/compilation")).Debug;
        }
    }
}
