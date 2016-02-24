namespace SmartConnect.Web.Controllers.Tests.Admin.Users
{
    using System.Web.Mvc;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using ViewModels.Common;

    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexShouldReturnCorrectViewModel()
        {
            var mockedUsersService = new JustMockUsersService();
            HeaderViewModel model = new HeaderViewModel()
            {
                Heading = "Users",
                SubHeading = string.Empty
            };

            var controller = new Controllers.Admin.Users.HomeController(mockedUsersService.Users);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual(model.Heading, (result.Model as HeaderViewModel).Heading);
            Assert.AreEqual(model.SubHeading, (result.Model as HeaderViewModel).SubHeading);
            Assert.AreEqual(model.BackgroundUrl, (result.Model as HeaderViewModel).BackgroundUrl);
        }
    }
}
