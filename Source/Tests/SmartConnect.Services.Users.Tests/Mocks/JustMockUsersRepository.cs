namespace SmartConnect.Services.Users.Tests.Mocks
{
    using System.Linq;
    using Data.Models;
    using Data.Repositories.Contracts;
    using Telerik.JustMock;

    public class JustMockUsersRepository : UsersRepositoryMock
    {
        protected override void ArrangeUsersRepositoryMock()
        {
            User user = this.FakeUserCollection.First();

            this.Users = Mock.Create<IRepository<User, string>>();
            Mock.Arrange(() => this.Users.Add(Arg.IsAny<User>())).DoNothing();
            Mock.Arrange(() => this.Users.All())
                .Returns(this.FakeUserCollection
                    .Where(x => !x.IsDeleted)
                    .AsQueryable());
            Mock.Arrange(() => this.Users.AllWithDeleted())
                .Returns(this.FakeUserCollection.AsQueryable());
            Mock.Arrange(() => this.Users.GetById("1"))
                .Returns(this.FakeUserCollection
                    .FirstOrDefault(x => x.Id == "1"));
            Mock.Arrange(() => this.Users.Delete(user))
                .DoInstead(() => user.IsDeleted = true);
            Mock.Arrange(() => this.Users.Delete(user.Id))
                .DoInstead(() => user.IsDeleted = true);
            Mock.Arrange(() => this.Users.HardDelete(user))
                .DoInstead(() => this.FakeUserCollection.Remove(user));
            Mock.Arrange(() => this.Users.HardDelete(user.Id))
                .DoInstead(() => this.FakeUserCollection.Remove(user));
            Mock.Arrange(() => this.Users.SaveChanges())
                .DoNothing();
        }
    }
}
