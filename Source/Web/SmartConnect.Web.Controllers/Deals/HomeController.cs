namespace SmartConnect.Web.Controllers.Deals
{
    using System.Web.Mvc;

    using Contracts;
    using Services.Users.Contracts;

    public class HomeController : BaseAuthorizationController
    {
        public HomeController(IUsersService users)
            : base(users)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}
