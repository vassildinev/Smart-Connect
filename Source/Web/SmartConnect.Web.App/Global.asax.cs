namespace SmartConnect.Web.App
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Configurations;
    using SmartConnect.Common.Constants;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AutoMapperConfig.RegisterMappings(Assemblies.ViewModels);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DatabaseConfig.RegisterDatabase();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ViewEnginesConfig.RegisterViewEngines(ViewEngines.Engines);
            ModelBinderProvidersConfig.RegisterModelBinderProviders();
        }
    }
}
