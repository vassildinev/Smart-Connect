namespace SmartConnect.Web.Controllers.Admin.Users
{
    using System.Web.Mvc;

    using Contracts;
    
    public class HomeController : BaseAuthorizationController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
