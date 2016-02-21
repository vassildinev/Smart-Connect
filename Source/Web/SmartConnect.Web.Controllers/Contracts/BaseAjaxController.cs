namespace SmartConnect.Web.Controllers.Contracts
{
    using Data.Models;
    using Services.Common.Contracts;

    public abstract class BaseAjaxController : BaseAuthorizationController
    {
        public BaseAjaxController(IDataService<User, string> users) 
            : base(users)
        {
        }
    }
}
