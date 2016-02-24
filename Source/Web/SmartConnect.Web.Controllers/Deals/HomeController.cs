namespace SmartConnect.Web.Controllers.Deals
{
    using System.Web.Mvc;

    using Contracts;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Deals.Contracts;
    using Services.Users.Contracts;
    using ViewModels.Common;
    using ViewModels.Deals;
    using Services.Sanitizers.Contracts;

    public class HomeController : BaseAuthorizationController
    {
        private const string IndexHeading = "Manage Deals";
        private const string IndexSubHeading = "Set objectives, win deals or create new ones";

        private IDealsService deals;
        private ISanitizerService sanitizer;

        public HomeController(IUsersService users, IDealsService deals, ISanitizerService sanitizer)
            : base(users)
        {
            this.deals = deals;
            this.sanitizer = sanitizer;
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

        public ActionResult New()
        {
            return this.PartialView("~/Views/Deals/Home/_CreateDealPartial.cshtml");
        }

        // Example of using a sanitizer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DealViewModel viewModel)
        {
            if (viewModel != null && this.ModelState.IsValid)
            {
                Deal deal = new Deal()
                {
                    Name = this.sanitizer.Sanitize(viewModel.Name),
                    ClientId = this.User.Identity.GetUserId(),
                    Value = viewModel.Value
                };

                this.deals.Create(deal);
                this.deals.SaveChanges();
            }

            return this.RedirectToAction("Index", "Home", new { area = "Deals" });
        }
    }
}
