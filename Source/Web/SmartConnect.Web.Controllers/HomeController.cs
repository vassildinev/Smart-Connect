namespace SmartConnect.Web.Controllers
{
    using System.Web.Mvc;

    using Contracts;
    using Data.Models;
    using Services.Cache.Contracts;
    using Services.Quotes.Contracts;
    using ViewModels;

    [RequireHttps]
    public class HomeController : BaseController
    {
        private IQuotesService quotes;
        private ICacheService cache;

        public HomeController(IQuotesService quotes, ICacheService cache)
        {
            this.quotes = quotes;
            this.cache = cache;
        }

        public ActionResult Index()
        {
            Quote randomQuote = this.cache.Get("QuoteOfTheDay", () => this.quotes.Random(), 24 * 60 * 60);
            return this.AutoMappedObjectView<Quote, QuoteViewModel>(this.View(randomQuote));
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