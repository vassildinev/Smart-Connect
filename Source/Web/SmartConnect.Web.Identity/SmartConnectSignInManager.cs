namespace SmartConnect.Web.Identity
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Data.Models;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;

    public class SmartConnectSignInManager : SignInManager<User, string>
    {
        public SmartConnectSignInManager(SmartConnectUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            var users = (SmartConnectUserManager)this.UserManager;

            return user.GenerateUserIdentityAsync(users);
        }

        public static SmartConnectSignInManager Create(IdentityFactoryOptions<SmartConnectSignInManager> options, IOwinContext context)
        {
            SmartConnectUserManager identity = context.GetUserManager<SmartConnectUserManager>();
            IAuthenticationManager authentication = context.Authentication;

            return new SmartConnectSignInManager(identity, authentication);
        }
    }
}
