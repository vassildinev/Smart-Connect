namespace SmartConnect.Services.Contacts.Contracts
{
    using System.Linq;

    using Common.Contracts;
    using Data.Models;

    public interface IMessagesService : IDataService<Message, int>
    {
        IQueryable<Message> GetByUserIdUnread(string userId);

        IQueryable<Message> GetByContactId(int contactId);
    }
}
