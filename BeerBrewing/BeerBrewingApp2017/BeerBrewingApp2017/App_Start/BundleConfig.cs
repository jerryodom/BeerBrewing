using System.Web;
using System.Web.Optimization;

namespace BeerBrewingApp2017
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Bundles we added for our app:


            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-cookies.js",
                        "~/Scripts/highcharts.js",
                        "~/Scripts/highcharts-ng.min.js"));

            //kept this code because later we may need the highchart
            //bundles.Add(new ScriptBundle("~/bundles/angular").Include(
            //            "~/Scripts/angular.js",
            //            "~/Scripts/angular-route.js",
            //            "~/Scripts/angular-cookies.js",
            //            "~/Scripts/highcharts.js",
            //            "~/Scripts/highcharts-ng.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").IncludeDirectory(
                      "~/Scripts/App", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/BeerBrewingBundle").Include(
        "~/Scripts/BeerBrewingApp/beerbrewingapp.module.js",
        "~/Scripts/BeerBrewingApp/About.controller.js",
        "~/Scripts/BeerBrewingApp/BeerRecipes.controller.js"
    ));
        }
    }
}
