namespace SmartConnect.Services.Users.Tests.Mocks
{
    using Data.Models;
    using Data.Repositories.Contracts;
    using System.Collections.Generic;

    public abstract class UsersRepositoryMock : IUsersRepositoryMock
    {
        public UsersRepositoryMock()
        {
            this.PopulateFakeData();
            this.ArrangeUsersRepositoryMock();
        }

        public IRepository<User, string> Users { get; protected set; }

        protected ICollection<User> FakeUserCollection { get; private set; }

        protected abstract void ArrangeUsersRepositoryMock();

        private void PopulateFakeData()
        {
            this.FakeUserCollection = new List<User>
            {
                new User() {Id = "1", IsDeleted = false },
                new User() { IsDeleted = true },
            };
        }
    }
}
