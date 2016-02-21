namespace SmartConnect.Web.Controllers
{
    using System.Web.Mvc;

    using Contracts;
    using ViewModels.Common;
    using ViewModels.StaticPages;

    public class StaticPagesController : BaseController
    {
        private const string IndexHeading = "Dashboard";
        private const string IndexSubHeading = "Select where you would like to go";

        private const string AboutHeading = "About the author";
        private const string AboutBackgroundUrl = "../../Images/about-background.jpg";
        private const string AboutSubHeading = "Telerik Academy 2015-2016 Student";

        private const string ContactHeading = "Contact me";
        private const string ContactSubHeading = "vassildinev@gmail.com";

        public ActionResult Dashboard()
        {
            HeaderViewModel header = new HeaderViewModel()
            {
                Heading = IndexHeading,
                SubHeading = IndexSubHeading
            };

            return this.View("Dashboard", header);
        }

        public ActionResult About()
        {
            HeaderViewModel header = new HeaderViewModel()
            {
                Heading = AboutHeading,
                BackgroundUrl = AboutBackgroundUrl,
                SubHeading = AboutSubHeading
            };

            AboutViewModel aboutModel = new AboutViewModel()
            {
                Header = header
            };

            return this.View(aboutModel);
        }

        public ActionResult Contact()
        {
            HeaderViewModel header = new HeaderViewModel()
            {
                Heading = ContactHeading,
                SubHeading = ContactSubHeading
            };

            ContactViewModel contactModel = new ContactViewModel()
            {
                Header = header
            };

            return this.View(contactModel);
        }
    }
}
