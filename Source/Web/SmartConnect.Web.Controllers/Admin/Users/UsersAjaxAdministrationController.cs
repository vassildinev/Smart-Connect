namespace SmartConnect.Web.Controllers.Admin.Users
{
    using Contracts;
    using Data.Models;
    using Services.Users.Contracts;
    using ViewModels.Admin.Users;

    public class UsersAjaxAdministrationController :
        KendoGridAdministrationController<User, AdminUserViewModel, string>,
        IKendoGridController<User, AdminUserViewModel, string>
    {
        public UsersAjaxAdministrationController(IUsersService users) 
            : base(users, users)
        {
        }
    }
}
