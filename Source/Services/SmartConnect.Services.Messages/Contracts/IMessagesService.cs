namespace SmartConnect.Services.Messages.Contracts
{
    using Common.Contracts;
    using Data.Models;

    public interface IMessagesService : IDataService<Message, int>
    {
    }
}
