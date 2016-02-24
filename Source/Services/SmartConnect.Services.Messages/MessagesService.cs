namespace SmartConnect.Services.Messages
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Models;
    using Data.Repositories.Contracts;

    public class MessagesService : IMessagesService
    {
        private IRepository<Message, int> messages;

        public MessagesService(IRepository<Message, int> messages)
        {
            this.messages = messages;
        }

        public IQueryable<Message> All()
        {
            return this.messages.All();
        }

        public IQueryable<Message> AllWithDeleted()
        {
            return this.messages.AllWithDeleted();
        }

        public void Create(Message entity)
        {
            this.messages.Add(entity);
        }

        public void Delete(int entityId)
        {
            this.messages.Delete(entityId);
        }

        public void Delete(Message entity)
        {
            this.messages.Delete(entity);
        }

        public Message GetById(int entityId)
        {
            return this.messages.GetById(entityId);
        }

        public void HardDelete(int entityId)
        {
            this.messages.HardDelete(entityId);
        }

        public void HardDelete(Message entity)
        {
            this.messages.HardDelete(entity);
        }

        public int SaveChanges()
        {
            return this.messages.SaveChanges();
        }

        public void Update(Message entity)
        {
            this.messages.Update(entity);
        }
    }
}
