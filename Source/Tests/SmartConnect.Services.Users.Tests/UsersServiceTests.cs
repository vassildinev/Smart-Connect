namespace SmartConnect.Services.Users.Tests
{
    using Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using Contracts;
    using Data.Models;

    [TestClass]
    public class UsersServiceTests
    {
        private IUsersRepositoryMock mockedUsersRepository;
        private IUsersService usersService;

        [TestInitialize]
        public void TestsBegin()
        {
            this.mockedUsersRepository = new JustMockUsersRepository();
            this.usersService = new UsersService(this.mockedUsersRepository.Users);
        }

        [TestMethod]
        public void AllShouldReturnOnlyNonDeletedEntities()
        {
            Assert.AreEqual(1, this.usersService.All().Count());
        }

        [TestMethod]
        public void AllWithDeletedShouldReturnAllEntities()
        {
            Assert.AreEqual(2, this.usersService.AllWithDeleted().Count());
        }

        [TestMethod]
        public void AddShouldNotThrow()
        {
            this.usersService.Create(new User());
        }

        [TestMethod]
        public void GetByIdShouldReturnEntity()
        {
            User user = this.usersService.GetById("1");
            Assert.AreEqual("1", user.Id);
        }

        [TestMethod]
        public void DeleteShouldReduceTheCountOfNonDeletedEntities()
        {
            User user = this.mockedUsersRepository.Users.All().First();
            this.usersService.Delete(user);
            Assert.AreEqual(0, this.usersService.All().Count());
        }

        [TestMethod]
        public void DeleteShouldReduceTheCountOfNonDeletedEntitiesWithId()
        {
            User user = this.mockedUsersRepository.Users.All().First();
            this.usersService.Delete(user.Id);
            Assert.AreEqual(0, this.usersService.All().Count());
        }

        [TestMethod]
        public void HardDeleteShouldReduceTheCountOfEntities()
        {
            User user = this.mockedUsersRepository.Users.All().First();
            this.usersService.HardDelete(user);
            Assert.AreEqual(1, this.usersService.AllWithDeleted().Count());
        }

        [TestMethod]
        public void HardDeleteShouldReduceTheCountOfEntitiesWithId()
        {
            User user = this.mockedUsersRepository.Users.All().First();
            this.usersService.HardDelete(user.Id);
            Assert.AreEqual(1, this.usersService.AllWithDeleted().Count());
        }
    }
}
