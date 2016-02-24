namespace SmartConnect.Services.Deals
{
    using System;
    using System.Linq;

    using Contracts;
    using Data.Models;
    using Data.Repositories.Contracts;

    public class RequirementsService : IRequirementsService
    {
        private IRepository<Requirement, int> requirements;

        public RequirementsService(IRepository<Requirement, int> requirements)
        {
            this.requirements = requirements;
        }

        public IQueryable<Requirement> All()
        {
            return this.requirements.All();
        }

        public IQueryable<Requirement> AllWithDeleted()
        {
            return this.requirements.AllWithDeleted();
        }

        public void Create(Requirement entity)
        {
            this.requirements.Add(entity);
        }

        public void Delete(int entityId)
        {
            this.requirements.Delete(entityId);
        }

        public void Delete(Requirement entity)
        {
            this.requirements.Delete(entity);
        }

        public IQueryable<Requirement> GetByDealId(int dealId)
        {
            return this.requirements
                .All()
                .Where(r => r.DealId == dealId)
                .OrderByDescending(r => r.Priority);
        }

        public Requirement GetById(int id)
        {
            return this.requirements.GetById(id);
        }

        public void HardDelete(int entityId)
        {
            this.HardDelete(entityId);
        }

        public void HardDelete(Requirement entity)
        {
            this.HardDelete(entity);
        }

        public int SaveChanges()
        {
            return this.requirements.SaveChanges();
        }

        public void Update(Requirement entity)
        {
            this.requirements.Update(entity);
        }
    }
}
