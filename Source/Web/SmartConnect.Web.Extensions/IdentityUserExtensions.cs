namespace SmartConnect.Web.Extensions
{
    using System.Linq;
    using System.Security.Principal;

    using Common.Constants;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Users.Contracts;
    using Infrastructure;

    public static class PrincipalExtensions
    {
        public static bool IsLoggedIn(this IPrincipal principal)
        {
            return principal.Identity.IsAuthenticated;
        }

        public static bool IsUser(this IPrincipal principal)
        {
            return principal.IsInRole(Roles.User);
        }

        public static bool IsModerator(this IPrincipal principal)
        {
            return principal.IsInRole(Roles.Moderator);
        }

        public static bool IsAdmin(this IPrincipal principal)
        {
            return principal.IsInRole(Roles.Admin);
        }

        public static bool HasUnreadMessages(this IPrincipal principal)
        {
            IUsersService users = ObjectFactory.Instance.GetInstance<IUsersService>();
            if (!principal.IsLoggedIn())
            {
                return false;
            }

            string userId = principal.Identity.GetUserId();
            User user = users.GetById(userId);
            
            return user.MessagesReceived.Any(m => !m.IsSeen);
        }
    }
}
