using System.Web;
using System.Web.Optimization;

namespace DoctorProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

             // plugins/datatables-bs4/css/dataTables.bootstrap4.min.css
             // plugins/datatables-responsive/css/responsive.bootstrap4.min.css     
             // plugins/datatables-buttons/css/buttons.bootstrap4.min.css
/*
            bundles.Add(new ScriptBundle("~/bundles/datatablesjs").Include(
            "~/Scripts/datatables-bs4/js/dataTables.bootstrap4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatablescss").Include(
                    "~/Scripts/datatables-bs4/css/dataTables.bootstrap4.min.css",
                    "~/Scripts/datatables-bs4/css/dataTables.bootstrap4.min.css"

                    ));
*/
        }
    }
}
