namespace SmartConnect.Web.Controllers.Contracts
{
    using System.Web.Mvc;

    using Data.Models;
    using Services.Common.Contracts;

    [Authorize]
    public abstract class BaseAjaxAuthorizationController : BaseAjaxController
    {
        public BaseAjaxAuthorizationController(IDataService<User, string> users) 
            : base(users)
        {
        }
    }
}
