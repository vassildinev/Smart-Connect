namespace SmartConnect.Web.Controllers.Contracts
{
    using Common.Constants;
    using System.Web.Mvc;

    [Authorize(Roles = Roles.Admin)]
    public class BaseAdministrationController : BaseController
    {
    }
}
