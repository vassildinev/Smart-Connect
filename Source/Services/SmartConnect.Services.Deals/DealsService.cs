namespace SmartConnect.Services.Deals
{
    using System.Linq;

    using Contracts;
    using Data.Models;
    using Data.Repositories.Contracts;

    public class DealsService : IDealsService
    {
        private IRepository<Deal, int> deals;

        public DealsService(IRepository<Deal, int> deals)
        {
            this.deals = deals;
        }

        public IQueryable<Deal> All()
        {
            return this.deals.All();
        }

        public IQueryable<Deal> AllWithDeleted()
        {
            return this.deals.AllWithDeleted();
        }

        public IQueryable<Deal> ByUserIdCurrent(string userId)
        {
            return this.deals
                .All()
                .Where(x => x.ExecuterId == userId && x.Status == DealStatus.InProgress);
        }

        public IQueryable<Deal> ByUserIdLost(string userId)
        {
            return this.deals
                .All()
                .Where(x => x.ExecuterId == userId && x.Status == DealStatus.Lost);
        }

        public IQueryable<Deal> ByUserIdOwn(string userId)
        {
            return this.deals
                .All()
                .Where(x => x.ClientId == userId);
        }

        public IQueryable<Deal> ByUserIdWon(string userId)
        {
            return this.deals
                .All()
                .Where(x => x.ExecuterId == userId && x.Status == DealStatus.Won);
        }

        public void Create(Deal entity)
        {
            this.deals.Add(entity);
        }

        public void Delete(int entityId)
        {
            this.deals.Delete(entityId);
        }

        public void Delete(Deal entity)
        {
            this.deals.Delete(entity);
        }

        public Deal GetById(int id)
        {
            return this.deals.GetById(id);
        }

        public void HardDelete(int entityId)
        {
            this.deals.HardDelete(entityId);
        }

        public void HardDelete(Deal entity)
        {
            this.deals.HardDelete(entity);
        }

        public int SaveChanges()
        {
            return this.deals.SaveChanges();
        }

        public void Update(Deal entity)
        {
            this.deals.Update(entity);
        }
    }
}
