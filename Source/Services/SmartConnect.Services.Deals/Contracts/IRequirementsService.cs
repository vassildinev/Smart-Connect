namespace SmartConnect.Services.Deals.Contracts
{
    using System.Linq;

    using Common.Contracts;
    using Data.Models;

    public interface IRequirementsService : IDataService<Requirement, int>
    {
        IQueryable<Requirement> GetByDealId(int dealId);
    }
}