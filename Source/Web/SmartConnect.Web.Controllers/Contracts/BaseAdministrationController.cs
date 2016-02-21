namespace SmartConnect.Web.Controllers.Contracts
{
    using System.Web.Mvc;

    using Common.Constants;
    using Data.Models;
    using Services.Common.Contracts;

    [Authorize(Roles = Roles.Admin)]
    public abstract class BaseAdministrationController : BaseAuthorizationController
    {
        public BaseAdministrationController(IDataService<User, string> users) 
            : base(users)
        {
        }
    }
}
