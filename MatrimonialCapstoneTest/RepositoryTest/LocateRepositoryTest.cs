using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;
using MatrimonialCapstoneApplication.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrimonialCapstoneTest.RepositoryTest
{
    public class LocateRepositoryTest
    {
        private MatrimonialContext _context;
        private IRepository<int, Locate> _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MatrimonialContext>()
                .UseInMemoryDatabase(databaseName: "MatrimonialDatabase")
                .Options;
            _context = new MatrimonialContext(options);

            _context.Database.EnsureDeletedAsync().Wait();
            _context.Database.EnsureCreatedAsync().Wait();

            _repository = new LocateRepository(_context); // Replace with your specific repository
        }

        [Test]
        public async Task Create_AddsEntityToContext()
        {
            var locate = new Locate { LocateId = 101, Lat = 72.000, Long = 83.222, PersonalDetailsId = 1 };
            await _repository.Create(locate);
            var result = await _repository.Get(locate.LocateId);
            Assert.NotNull(result);
            Assert.AreEqual(locate.LocateId, result.LocateId);
        }

        [Test]
        public async Task Delete_RemovesEntityFromContext()
        {
            var locate = new Locate { LocateId = 101, Lat = 72.000, Long = 83.222, PersonalDetailsId = 1 };
            await _repository.Create(locate);
            var deletedLocate = await _repository.Delete(locate.LocateId);
            var result = await _repository.Get(locate.LocateId);
            Assert.IsNull(result);
            Assert.AreEqual(locate.LocateId, deletedLocate.LocateId);
        }

        [Test]
        public async Task GetAll_ReturnsAllEntities()
        {
            var locates = new List<Locate>
            {
                new Locate { LocateId = 101, Lat = 72.000, Long = 83.222, PersonalDetailsId = 1 },
                new Locate { LocateId = 102, Lat = 73.000, Long = 84.222, PersonalDetailsId = 2 }
            };

            foreach (var locate in locates)
            {
                await _repository.Create(locate);
            }

            var result = await _repository.Get();
            Assert.AreEqual(locates.Count+1, result.Count());
        }

        [Test]
        public async Task Update_UpdatesEntityInContext()
        {
            var locate = new Locate { LocateId = 101, Lat = 72.000, Long = 83.222, PersonalDetailsId = 1 };
            await _repository.Create(locate);
            locate.Lat = 74.000;
            var updatedLocate = await _repository.Update(locate);
            var result = await _repository.Get(updatedLocate.LocateId);
            Assert.NotNull(result);
            Assert.AreEqual(74.000, result.Lat);
        }
    }
}
