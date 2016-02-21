namespace SmartConnect.Web.Controllers.Contracts
{
    using System.Web.Mvc;

    using Common.Constants;
    using Data.Models;
    using Services.Common.Contracts;

    [Authorize(Roles = Roles.Admin)]
    public abstract class BaseAjaxAdministrationController : BaseAjaxController
    {
        public BaseAjaxAdministrationController(IDataService<User, string> users) 
            : base(users)
        {
        }
    }
}
