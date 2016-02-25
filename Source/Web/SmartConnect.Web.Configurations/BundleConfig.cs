namespace SmartConnect.Web.Configurations
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery.min.js"));

            // For some reason if both jquery scripts are in one bundle, unobtrusive is
            // always loaded first no matter the order of declaration... 
            // => "jQuery is not defined" error in the console

            bundles.Add(new ScriptBundle("~/bundles/jquery-unobtrusive").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/Kendo/kendo.all.min.js",
                "~/Scripts/Kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                "~/Scripts/jquery.signalR-*",
                "~/signalr/hubs"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/Theme/clean-blog.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/clean-blog.css",
                      "~/Content/fonts.css",
                      "~/Content/fonts-other.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/KendoCss").Include(
                      "~/Content/Kendo/kendo.common.min.css",
                      "~/Content/Kendo/kendo.default.min.css"));
        }
    }
}
