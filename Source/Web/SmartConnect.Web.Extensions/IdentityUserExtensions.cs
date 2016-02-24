namespace SmartConnect.Web.Extensions
{
    using System.Linq;
    using System.Security.Principal;

    using Common.Constants;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Users.Contracts;
    using Infrastructure;
    using Services.Contacts.Contracts;

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
            IMessagesService messages = ObjectFactory.Instance.GetInstance<IMessagesService>();
            if (!principal.IsLoggedIn())
            {
                return false;
            }

            string userId = principal.Identity.GetUserId();
            var unreadMessages = messages.GetByUserIdUnread(userId);

            return unreadMessages.Count() > 0;
        }
    }
}
