namespace SmartConnect.Services.Identity.Authentication
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Data.Models;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;

    public class AuthenticationService : SignInManager<User, string>
    {
        public AuthenticationService(IdentityService userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            var users = (IdentityService)this.UserManager;

            return user.GenerateUserIdentityAsync(users);
        }

        public static AuthenticationService Create(IdentityFactoryOptions<AuthenticationService> options, IOwinContext context)
        {
            IdentityService identity = context.GetUserManager<IdentityService>();
            IAuthenticationManager authentication = context.Authentication;

            return new AuthenticationService(identity, authentication);
        }
    }
}
