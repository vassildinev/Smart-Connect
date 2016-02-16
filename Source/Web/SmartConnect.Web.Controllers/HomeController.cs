namespace SmartConnect.Web.Controllers
{
    using System.Web.Mvc;

    using Contracts;
    using Services.Quotes.Contracts;
    using Infrastructure;
    using ViewModels;
    using Data.Models;
    using System;
    using Services.Cache.Contracts;

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
            var mapper = StandardMapperObjectsProvider.Instance.Mapper;

            Quote randomQuote = this.cache.Get("QuoteOfTheDay", () => this.quotes.Random(), 24 * 60 * 60);
            QuoteViewModel randomQuoteViewModel = new QuoteViewModel();
            randomQuoteViewModel = mapper.Map(randomQuote, randomQuoteViewModel);
            
            return View(randomQuoteViewModel);
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