namespace SmartConnect.Services.Contacts
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Models;
    using Data.Repositories.Contracts;

    public class ContactsService : IContactsService
    {
        private IRepository<Contact, int> contacts;

        public ContactsService(IRepository<Contact, int> contacts)
        {
            this.contacts = contacts;
        }

        public IQueryable<Contact> All()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Contact> AllWithDeleted()
        {
            throw new NotImplementedException();
        }

        public void Create(Contact entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Delete(Contact entity)
        {
            throw new NotImplementedException();
        }

        public Contact GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Contact> GetByUserId(string userId)
        {
            return this.contacts.All().Where(c => c.SenderId == userId || c.ReceiverId == userId);
        }

        public void HardDelete(int entityId)
        {
            throw new NotImplementedException();
        }

        public void HardDelete(Contact entity)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
