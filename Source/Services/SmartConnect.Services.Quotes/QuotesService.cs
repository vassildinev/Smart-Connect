namespace SmartConnect.Services.Quotes
{
    using Contracts;
    using Data.Models;
    using Data.Repositories.Contracts;

    public class QuotesService : IQuotesService
    {
        private IRepository<Quote, int> quotes;

        public QuotesService(IRepository<Quote, int> quotes)
        {
            this.quotes = quotes;
        }
    }
}
