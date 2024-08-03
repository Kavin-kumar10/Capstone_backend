using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrimonialCapstoneTest.RepositoryTest
{
    public class UserRepositoryTest
    {
        private MatrimonialContext _context;
        private IRepository<int,User> _repo;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MatrimonialContext>()
                .UseInMemoryDatabase(databaseName: "MatrimonialDatabase")
                .Options;
            _context = new MatrimonialContext(options);

            _context.Database.EnsureDeletedAsync().Wait();
            _context.Database.EnsureCreatedAsync().Wait();

            _repo = new UserRepository(_context);

        }


        [Test]
        public async Task Add_User_PassTest()
        {
            //Arrange
            User entity = new User() { Name="kavin", MemberId = 104,Email="kavinkumar.prof@gmail.com", Password = Encoding.UTF8.GetBytes("yourPassword"), HashedPassword = Encoding.UTF8.GetBytes("yourPassword"), Status = "Active" };
            //Action
            var result = await _repo.Create(entity);
            //Assert
            Assert.That(result.Status, Is.EqualTo("Active"));
            Console.WriteLine(result.Status);
        }

        [Test]
        public async Task Add_User_FailTest()
        {
            try
            {
                //Arrange
                User entity = new User() { Name="kavin", MemberId = 101, Email = "kavinkumar.prof@gmail.com", Password = Encoding.UTF8.GetBytes("yourPassword"), HashedPassword = Encoding.UTF8.GetBytes("yourPassword"), Status = "Active" };
                //Action
                var result = await _repo.Create(entity);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.That(ex.Message, Is.EqualTo("An item with the same key has already been added. Key: 101"));
            }
        }

        [Test]
        public async Task Get_Users_PassTest()
        {
            //Arrange
            User entity = new User() {Name = "kavin", MemberId = 101, Email = "kavinkumar.prof@gmail.com", Password = Encoding.UTF8.GetBytes("yourPassword"), HashedPassword = Encoding.UTF8.GetBytes("yourPassword"), Status = "Active" };
            await _repo.Create(entity);

            var result = await _repo.Get();
            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task Get_Users_byId_PassTest()
        {
            //Arrange
            User entity = new User() {Name="kavin", MemberId = 101, Email = "kavinkumar.prof@gmail.com", Password = Encoding.UTF8.GetBytes("yourPassword"), HashedPassword = Encoding.UTF8.GetBytes("yourPassword") };
            _repo.Create(entity);


            var result = await _repo.Get(101);
            Assert.That(result.Status, Is.EqualTo("Disabled"));
        }

        [Test]
        public async Task Get_User_byId_FailTest()
        {
            try
            {
                var result = await _repo.Get(501);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("User Not Found"));
            }
        }

        [Test]
        public async Task Update_User_PassTest()
        {
            //Arrange
            User entity = new User() { Name="kavin", MemberId = 101, Email = "kavinkumar.prof@gmail.com", Password = Encoding.UTF8.GetBytes("yourPassword"), HashedPassword = Encoding.UTF8.GetBytes("yourPassword"), Status = "Active" };
            await _repo.Create(entity);

            //Action
            var result = await _repo.Update(entity);

            //Assert
            Assert.That(result.Status, Is.EqualTo("Active"));
        }

        [Test]
        public async Task Update_User_FailTest()
        {
            try
            {
                //Arrange
                User entity = new User() { Name="kavin",MemberId = 106, Email = "kavinkumar.prof@gmail.com", Password = Encoding.UTF8.GetBytes("yourPassword"), HashedPassword = Encoding.UTF8.GetBytes("yourPassword"), Status = "Active" };
                //Action
                var result = await _repo.Update(entity);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.That(ex.Message, Is.EqualTo("Attempted to update or delete an entity that does not exist in the store."));
            }
        }

        [Test]
        public async Task Delete_User_PassTest()
        {
            //Arrange
            User entity = new User() {Name = "kavin", MemberId = 101, Email = "kavinkumar.prof@gmail.com", Password = Encoding.UTF8.GetBytes("yourPassword"), HashedPassword = Encoding.UTF8.GetBytes("yourPassword"), Status = "Active" };
            _repo.Create(entity);
            //Action
            var result = await _repo.Delete(101);
            //Assert
            Assert.That(result.MemberId, Is.EqualTo(101));
        }

        [Test]
        public async Task Delete_User_FailTest()
        {
            //Action
            var result = await _repo.Delete(150);
            //Assert
            Assert.That(result, Is.Null);
        }
    }
}
