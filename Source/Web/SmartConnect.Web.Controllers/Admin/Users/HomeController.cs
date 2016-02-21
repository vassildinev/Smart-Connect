namespace SmartConnect.Web.Controllers.Admin.Users
{

    using Contracts;
    using Data.Models;
    using Services.Users.Contracts;
    using ViewModels.Admin.Users;

    public class HomeController : 
        KendoGridAdministrationController<User, AdminUserViewModel, string>,
        IKendoGridAdministrationController<User, AdminUserViewModel, string>
    {
        public HomeController(IUsersService users)
            : base(users, users)
        {
            this.indexHeading = "Users";
        }
    }
}
