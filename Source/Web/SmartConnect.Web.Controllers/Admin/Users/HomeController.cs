namespace SmartConnect.Web.Controllers.Admin.Users
{
    using System.Web.Mvc;

    using Contracts;
    using ViewModels.Common;

    public class HomeController : BaseAdministrationController
    {
        private const string IndexHeading = "Users";
        private const string IndexSubHeading = "";

        public ActionResult Index()
        {
            HeaderViewModel model = new HeaderViewModel()
            {
                Heading = IndexHeading,
                SubHeading = IndexSubHeading
            };

            return this.View(model);
        }
    }
}
