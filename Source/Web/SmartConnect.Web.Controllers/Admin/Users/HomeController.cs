namespace SmartConnect.Web.Controllers.Admin.Users
{
    using Contracts;
    using Services.Users.Contracts;

    public class HomeController : BaseAdministrationController
    {
        public HomeController(IUsersService users)
            : base(users)
        {
            this.indexHeading = "Users";
        }
    }
}
