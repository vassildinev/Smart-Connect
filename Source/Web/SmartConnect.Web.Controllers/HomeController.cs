namespace SmartConnect.Web.Controllers
{
    using System.Web.Mvc;

    using Contracts;
    using Data.Models;
    using Services.Cache.Contracts;
    using Services.Quotes.Contracts;
    using ViewModels.Home;
    using ViewModels.Common;

    [RequireHttps]
    public class HomeController : BaseController
    {
        private const string IndexHeading = "Smart-Connect";
        private const string IndexBackgroundUrl = "../../Images/home-content-background.jpg";
        private const string IndexSubHeading = "Client management like never before!";

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
            QuoteViewModel mappedQuote = this.Mapper.Map<QuoteViewModel>(randomQuote);
            HeaderViewModel header = new HeaderViewModel()
            {
                Heading = IndexHeading,
                BackgroundUrl = IndexBackgroundUrl,
                SubHeading = IndexSubHeading
            };

            IndexViewModel indexModel = new IndexViewModel
            {
                Header = header,
                DailyQuote = mappedQuote
            };

            return this.View(indexModel);
        }
    }
}