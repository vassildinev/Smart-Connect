namespace SmartConnect.Web.Controllers.Contacts
{
    using System.Web.Mvc;

    using Contracts;
    using Services.Users.Contracts;
    using ViewModels.Common;

    public class HomeController : BaseAuthorizationController
    {
        private const string IndexHeading = "Manage Contacts";
        private const string IndexSubHeading = "Instant messaging";

        public HomeController(IUsersService users)
            : base(users)
        {
        }

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
