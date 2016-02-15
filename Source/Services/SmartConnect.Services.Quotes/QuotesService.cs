namespace SmartConnect.Services.Quotes
{
    using System;
    using System.Linq;

    using Common.Helpers;
    using Contracts;
    using Data.Models;
    using Data.Repositories.Contracts;
    using SmartConnect.Common.Exceptions;

    public class QuotesService : IQuotesService
    {
        private IRepository<Quote, int> quotes;

        public QuotesService(IRepository<Quote, int> quotes)
        {
            if(quotes == null)
            {
                throw new DataServiceInitializeException(
                    ServicesHelper
                        .GetNullDependencyMessage(nameof(IRepository<Quote, int>))
                    );
            }

            this.quotes = quotes;
        }

        public IQueryable<Quote> All()
        {
            return this.quotes.All();
        }

        public IQueryable<Quote> AllWithDeleted()
        {
            return this.quotes.AllWithDeleted();
        }

        public void Create(Quote entity)
        {
            this.quotes.Add(entity);
        }

        public void Delete(int entityId)
        {
            this.quotes.Delete(entityId);
        }

        public void Delete(Quote entity)
        {
            this.quotes.Delete(entity);
        }

        public void HardDelete(int entityId)
        {
            this.quotes.HardDelete(entityId);
        }

        public void HardDelete(Quote entity)
        {
            this.quotes.HardDelete(entity);
        }

        public Quote Random()
        {
            var quote = this
                .All()
                .ToList()
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault();

            return quote;
        }

        public void Update(Quote entity)
        {
            this.quotes.Update(entity);
        }
    }
}
