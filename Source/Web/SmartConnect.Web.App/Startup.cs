[assembly: Microsoft.Owin.OwinStartup(typeof(SmartConnect.Web.App.Startup))]
namespace SmartConnect.Web.App
{
    using Configurations;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app) => AuthConfig.ConfigureAuth(app);
    }
}
