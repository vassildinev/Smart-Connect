namespace SmartConnect.Web.Controllers.Contracts
{
    using System.Web.Mvc;

    using Common.Constants;
    using Data.Models;
    using Services.Common.Contracts;
    using ViewModels.Common;

    [Authorize(Roles = Roles.Admin)]
    public abstract class BaseAdministrationController : BaseAuthorizationController
    {
        protected string indexHeading = string.Empty;
        protected string indexSubHeading = string.Empty;

        public BaseAdministrationController(IDataService<User, string> users)
            : base(users)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            HeaderViewModel model = new HeaderViewModel()
            {
                Heading = this.indexHeading,
                SubHeading = this.indexSubHeading
            };

            return this.View(model);
        }
    }
}
