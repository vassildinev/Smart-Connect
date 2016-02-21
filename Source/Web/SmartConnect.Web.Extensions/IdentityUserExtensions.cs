namespace SmartConnect.Web.Extensions
{
    using System.Security.Principal;

    using Common.Constants;

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
    }
}
