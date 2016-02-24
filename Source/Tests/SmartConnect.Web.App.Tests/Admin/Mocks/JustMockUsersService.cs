namespace SmartConnect.Web.Controllers.Tests.Admin.Mocks
{
    using Services.Users.Contracts;
    using Data.Models;
    using Telerik.JustMock;

    public class JustMockUsersService : UsersServiceMock
    {
        public override void ArrangeUsersServiceMock()
        {
            this.Users = Mock.Create<IUsersService>();
            Mock
                .Arrange(() => this.Users.GetById(Arg.IsAny<string>()))
                .Returns(new User() { });
        }
    }
}
