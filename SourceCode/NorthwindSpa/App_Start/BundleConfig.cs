using System.Web;
using System.Web.Optimization;

namespace NorthwindSpa
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-resource.js",
                        "~/Scripts/angular-cookies.js",
                        "~/Scripts/angular-animate.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-ui").Include(
                        "~/Scripts/angular-ui/ui-bootstrap.js",
                        "~/Scripts/angular-ui/ui-bootstrap-tpls.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-components").Include(
                        "~/Scripts/toaster.js",
                        "~/Scripts/ng-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/app/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/services").Include(
                        "~/app/services/TranslationService.js",
                        "~/app/services/UrlBuilder.js",
                        "~/app/services/SupplierService.js",
                        "~/app/services/CategoryService.js",
                        "~/app/services/ProductService.js",
                        "~/app/services/CustomerService.js",
                        "~/app/services/EmployeeService.js",
                        "~/app/services/ShipperService.js",
                        "~/app/services/RegionService.js",
                        "~/app/services/OrderService.js",
                        "~/app/services/UnitOfWork.js"));

            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
                        "~/app/controllers/HomeController.js",
                        "~/app/controllers/SupplierController.js",
                        "~/app/controllers/CategoryController.js",
                        "~/app/controllers/ProductController.js",
                        "~/app/controllers/CustomerController.js",
                        "~/app/controllers/EmployeeController.js",
                        "~/app/controllers/ShipperController.js",
                        "~/app/controllers/RegionController.js",
                        "~/app/controllers/OrderController.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/angular-ui").Include(
                      "~/Content/ui-bootstrap-csp.css"));

            bundles.Add(new StyleBundle("~/Content/angular").Include(
                      "~/Content/toaster.css",
                      "~/Content/ng-table.css"));
        }
    }
}
