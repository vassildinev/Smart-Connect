namespace SmartConnect.Web.Controllers.Admin.Quotes
{
    using Contracts;
    using Services.Users.Contracts;

    public class HomeController : BaseAdministrationController
    {
        public HomeController(IUsersService users)
            : base(users)
        {
            this.indexHeading = "Quotes";
        }
    }
}
