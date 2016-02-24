namespace SmartConnect.Services.Users.Tests.Mocks
{
    using Data.Models;
    using Data.Repositories.Contracts;

    public interface IUsersRepositoryMock
    {
        IRepository<User, string> Users { get; }
    }
}
