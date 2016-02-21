namespace SmartConnect.Services.Users
{
    using System.Linq;

    using Contracts;
    using Data.Models;
    using Data.Repositories.Contracts;

    public class UsersService : IUsersService
    {
        private IRepository<User, string> users;

        public UsersService(IRepository<User, string> users)
        {
            this.users = users;
        }

        public IQueryable<User> All()
        {
            return this.users.All();
        }

        public IQueryable<User> AllWithDeleted()
        {
            return this.users.AllWithDeleted();
        }

        public void Create(User entity)
        {
            // TODO: Implement creating users
        }

        public void Delete(string entityId)
        {
            this.users.Delete(entityId);
        }

        public void Delete(User entity)
        {
            this.users.Delete(entity);
        }

        public User GetById(string id)
        {
            return this.users.GetById(id);
        }

        public void HardDelete(string entityId)
        {
            this.users.HardDelete(entityId);
        }

        public void HardDelete(User entity)
        {
            this.users.HardDelete(entity);
        }

        public int SaveChanges()
        {
            return this.users.SaveChanges();
        }

        public void Update(User entity)
        {
            this.users.Update(entity);
        }
    }
}
