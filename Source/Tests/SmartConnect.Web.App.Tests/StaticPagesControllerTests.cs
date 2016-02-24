namespace SmartConnect.Web.App.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Mvc;
    using ViewModels.Common;
    using ViewModels.StaticPages;
    using Web.Controllers;

    [TestClass]
    public class StaticPagesControllerTests
    {
        private const string IndexHeading = "Dashboard";
        private const string IndexSubHeading = "Select where you would like to go";

        private const string AboutHeading = "About the author";
        private const string AboutBackgroundUrl = "../../Images/about-background.jpg";
        private const string AboutSubHeading = "Telerik Academy 2015-2016 Student";

        private const string ContactHeading = "Contact me";
        private const string ContactSubHeading = "vassildinev@gmail.com";

        [TestMethod]
        public void DashboardShouldReturnCorrectView()
        {
            var controller = new StaticPagesController();
            var result = controller.Dashboard() as ViewResult;
            Assert.AreEqual("Dashboard", result.ViewName);
        }

        [TestMethod]
        public void DashboardShouldReturnCorrectViewModel()
        {
            HeaderViewModel header = new HeaderViewModel()
            {
                Heading = IndexHeading,
                SubHeading = IndexSubHeading
            };

            var controller = new StaticPagesController();
            var result = controller.Dashboard() as ViewResult;
            Assert.AreEqual(header.Heading, (result.Model as HeaderViewModel).Heading);
            Assert.AreEqual(header.SubHeading, (result.Model as HeaderViewModel).SubHeading);
            Assert.AreEqual(header.BackgroundUrl, (result.Model as HeaderViewModel).BackgroundUrl);
        }

        [TestMethod]
        public void ContactShouldReturnCorrectView()
        {
            var controller = new StaticPagesController();
            var result = controller.Contact() as ViewResult;
            Assert.AreEqual("Contact", result.ViewName);
        }

        [TestMethod]
        public void ContactShouldReturnCorrectViewModel()
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

            var controller = new StaticPagesController();
            var result = controller.Contact() as ViewResult;
            Assert.AreEqual(contactModel.Header.Heading, (result.Model as ContactViewModel).Header.Heading);
            Assert.AreEqual(contactModel.Header.SubHeading, (result.Model as ContactViewModel).Header.SubHeading);
            Assert.AreEqual(contactModel.Header.BackgroundUrl, (result.Model as ContactViewModel).Header.BackgroundUrl);
        }

        [TestMethod]
        public void AboutShouldReturnCorrectView()
        {
            var controller = new StaticPagesController();
            var result = controller.About() as ViewResult;
            Assert.AreEqual("About", result.ViewName);
        }

        [TestMethod]
        public void AboutShouldReturnCorrectViewModel()
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

            var controller = new StaticPagesController();
            var result = controller.About() as ViewResult;
            Assert.AreEqual(aboutModel.Header.Heading, (result.Model as AboutViewModel).Header.Heading);
            Assert.AreEqual(aboutModel.Header.SubHeading, (result.Model as AboutViewModel).Header.SubHeading);
            Assert.AreEqual(aboutModel.Header.BackgroundUrl, (result.Model as AboutViewModel).Header.BackgroundUrl);
        }
    }
}
