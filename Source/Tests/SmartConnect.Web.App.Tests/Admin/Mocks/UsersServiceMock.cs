namespace SmartConnect.Web.Controllers.Tests.Admin.Mocks
{
    using Services.Users.Contracts;

    public abstract class UsersServiceMock : IUsersServiceMock
    {
        public IUsersService Users { get; protected set; }

        public abstract void ArrangeUsersServiceMock();
    }
}
