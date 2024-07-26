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
    public class PictureRepositoryTests
    {
        private MatrimonialContext _context;
        private IRepository<int, Picture> _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MatrimonialContext>()
                .UseInMemoryDatabase(databaseName: "MatrimonialDatabase")
                .Options;
            _context = new MatrimonialContext(options);

            _context.Database.EnsureDeletedAsync().Wait();
            _context.Database.EnsureCreatedAsync().Wait();

            _repository = new PictureRepository(_context);
        }

        [Test]
        public async Task Create_AddsEntityToContext()
        {
            var picture = new Picture { PictureId = 101, PictureUrl = "http://example.com/image1.jpg", PersonalDetailsId = 1 };

            await _repository.Create(picture);

            var result = await _repository.Get(picture.PictureId);

            Assert.NotNull(result);
            Assert.AreEqual(picture.PictureId, result.PictureId);
        }

        [Test]
        public async Task Delete_RemovesEntityFromContext()
        {
            var picture = new Picture { PictureId = 101, PictureUrl = "http://example.com/image1.jpg", PersonalDetailsId = 1 };
            await _repository.Create(picture);

            var deletedPicture = await _repository.Delete(picture.PictureId);

            var result = await _repository.Get(picture.PictureId);

            Assert.IsNull(result);
            Assert.AreEqual(picture.PictureId, deletedPicture.PictureId);
        }

        [Test]
        public async Task GetAll_ReturnsAllEntities()
        {
            var pictures = new List<Picture>
            {
                new Picture { PictureId = 101, PictureUrl = "http://example.com/image1.jpg", PersonalDetailsId = 1 },
                new Picture { PictureId = 102, PictureUrl = "http://example.com/image2.jpg", PersonalDetailsId = 1 }
            };

            foreach (var picture in pictures)
            {
                await _repository.Create(picture);
            }

            var result = await _repository.Get();

            Assert.AreEqual(4, result.Count());
        }

        [Test]
        public async Task Update_UpdatesEntityInContext()
        {
            var picture = new Picture { PictureId = 101, PictureUrl = "http://example.com/image1.jpg", PersonalDetailsId = 1 };
            await _repository.Create(picture);

            picture.PictureUrl = "http://example.com/image1_updated.jpg";
            var updatedPicture = await _repository.Update(picture);

            var result = await _repository.Get(updatedPicture.PictureId);

            Assert.NotNull(result);
            Assert.AreEqual("http://example.com/image1_updated.jpg", result.PictureUrl);
        }
    }
}
