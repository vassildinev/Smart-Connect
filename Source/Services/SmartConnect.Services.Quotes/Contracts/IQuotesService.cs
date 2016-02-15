namespace SmartConnect.Services.Quotes.Contracts
{
    using Common.Contracts;
    using Data.Models;

    public interface IQuotesService : IDataService<Quote, int>
    {
        Quote Random();
    }
}
