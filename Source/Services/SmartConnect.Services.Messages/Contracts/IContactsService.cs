namespace SmartConnect.Services.Contacts.Contracts
{
    using System.Linq;

    using Common.Contracts;
    using Data.Models;

    public interface IContactsService : IDataService<Contact, int>
    {
        IQueryable<Contact> GetByUserId(string userId);
    }
}
