namespace SmartConnect.Services.Users.Contracts
{
    using Common.Contracts;
    using Data.Models;

    public interface IUsersService : IDataService<User, string>
    {
    }
}
