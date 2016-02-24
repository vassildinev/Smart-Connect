namespace SmartConnect.Services.Deals.Contracts
{
    using System.Linq;

    using Common.Contracts;
    using Data.Models;

    public interface IDealsService : IDataService<Deal, int>
    {
        IQueryable<Deal> ByUserIdCurrent(string userId);

        IQueryable<Deal> ByUserIdWon(string userId);

        IQueryable<Deal> ByUserIdLost(string userId);

        IQueryable<Deal> ByUserIdOwn(string userId);
    }
}
