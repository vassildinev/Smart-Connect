[assembly: Microsoft.Owin.OwinStartup(typeof(SmartConnect.Web.App.Startup))]
namespace SmartConnect.Web.App
{
    using System;

    using Configurations.HttpHandlers;
    using Data;
    using Data.Models;
    using Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.Facebook;
    using Microsoft.Owin.Security.Google;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app) => this.ConfigureAuth(app);

        private void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new SmartConnectDbContext());
            app.CreatePerOwinContext(
                (IdentityFactoryOptions<SmartConnectUserManager> options, IOwinContext context) =>
                new SmartConnectUserManager(
                    new UserStore<User>(context.Get<SmartConnectDbContext>()),
                    options));
            app.CreatePerOwinContext(
                (IdentityFactoryOptions<SmartConnectSignInManager> options, IOwinContext context) =>
                new SmartConnectSignInManager(
                    context.GetUserManager<SmartConnectUserManager>(),
                    context.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<SmartConnectUserManager, User>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            var facebookOptions = new FacebookAuthenticationOptions()
            {
                AppId = "985705804847366",
                AppSecret = "60f3dd8843d253be4df4c7df53dda6e5",
                BackchannelHttpHandler = new FacebookBackchannelHandler(),
                UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,name,email,first_name,last_name,location"
            };

            facebookOptions.Scope.Add("email");
            app.UseFacebookAuthentication(facebookOptions);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "223740515644-941v7r26af6sjl5rdsb1oupkcn85mob6.apps.googleusercontent.com",
                ClientSecret = "44TORONTMTTGYpg5j1GcEULS"
            });
        }
    }
}
