namespace SmartConnect.Web.Controllers
{
    using System.Web.Mvc;

    using Contracts;
    using Services.Quotes.Contracts;

    public class HomeController : BaseController
    {
        private IQuotesService quotes;

        public HomeController(IQuotesService quotes)
        {
            this.quotes = quotes;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}