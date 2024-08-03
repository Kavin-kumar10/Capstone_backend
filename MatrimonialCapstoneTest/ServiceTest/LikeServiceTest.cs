//using MatrimonialCapstoneApplication.Context;
//using MatrimonialCapstoneApplication.Exceptions;
//using MatrimonialCapstoneApplication.Interfaces;
//using MatrimonialCapstoneApplication.Models;
//using MatrimonialCapstoneApplication.Services;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MatrimonialCapstoneTest.ServiceTest
//{
//    public class LikeServiceTest
//    {
//        private Mock<IRepository<int, Like>> _mockRepo;
//        private LikeServices _likeService;
//        private MatrimonialContext _context;

//        [SetUp]
//        public void Setup()
//        {
//            var options = new DbContextOptionsBuilder<MatrimonialContext>()
//                .UseInMemoryDatabase(databaseName: "MatrimonialDatabase")
//                .Options;
//            _context = new MatrimonialContext(options);

//            _context.Database.EnsureDeletedAsync().Wait();
//            _context.Database.EnsureCreatedAsync().Wait();

//            _mockRepo = new Mock<IRepository<int, Like>>();
//            _likeService = new IServices<int(_mockRepo.Object);
//        }

//        [Test]
//        public async Task CreateLike_CreatesEntity()
//        {
//            var like = new Like { LikeId = 1, LikedById = 101, LikedId = 202, CreatedAt = DateTime.Now };
//            _mockRepo.Setup(repo => repo.Create(like)).ReturnsAsync(like);

//            var result = await _likeService.Create(like);

//            Assert.NotNull(result);
//            Assert.AreEqual(like.LikeId, result.LikeId);
//        }

//        [Test]
//        public void CreateLike_ThrowsUnableToCreateException_WhenEntityIsNull()
//        {
//            _mockRepo.Setup(repo => repo.Create(It.IsAny<Like>())).ReturnsAsync((Like)null);

//            Assert.ThrowsAsync<UnableToCreateException>(() => _likeService.Create(new Like()));
//        }

//        [Test]
//        public async Task DeleteLike_DeletesEntity()
//        {
//            var like = new Like { LikeId = 1, LikedById = 101, LikedId = 202, CreatedAt = DateTime.Now };
//            _mockRepo.Setup(repo => repo.Delete(like.LikeId)).ReturnsAsync(like);

//            var result = await _likeService.Delete(like.LikeId);

//            Assert.NotNull(result);
//            Assert.AreEqual(like.LikeId, result.LikeId);
//        }

//        [Test]
//        public void DeleteLike_ThrowsNotFoundException_WhenEntityIsNull()
//        {
//            _mockRepo.Setup(repo => repo.Delete(It.IsAny<int>())).ReturnsAsync((Like)null);

//            Assert.ThrowsAsync<NotFoundException>(() => _likeService.Delete(1));
//        }

//        [Test]
//        public async Task GetAllLikes_ReturnsAllEntities()
//        {
//            var likes = new List<Like>
//            {
//                new Like { LikeId = 1, LikedById = 101, LikedId = 202, CreatedAt = DateTime.Now },
//                new Like { LikeId = 2, LikedById = 103, LikedId = 204, CreatedAt = DateTime.Now }
//            };

//            _mockRepo.Setup(repo => repo.Get()).ReturnsAsync(likes);

//            var result = await _likeService.GetAll();

//            Assert.AreEqual(2, result.Count());
//        }

//        [Test]
//        public void GetAllLikes_ThrowsNotFoundException_WhenEntitiesAreNull()
//        {
//            _mockRepo.Setup(repo => repo.Get()).ReturnsAsync((IEnumerable<Like>)null);

//            Assert.ThrowsAsync<NotFoundException>(() => _likeService.GetAll());
//        }

//        [Test]
//        public async Task GetLikeById_ReturnsEntity()
//        {
//            var like = new Like { LikeId = 1, LikedById = 101, LikedId = 202, CreatedAt = DateTime.Now };
//            _mockRepo.Setup(repo => repo.Get(like.LikeId)).ReturnsAsync(like);

//            var result = await _likeService.GetById(like.LikeId);

//            Assert.NotNull(result);
//            Assert.AreEqual(like.LikeId, result.LikeId);
//        }

//        [Test]
//        public async Task UpdateLike_UpdatesEntity()
//        {
//            var existingLike = new Like { LikeId = 1, LikedById = 101, LikedId = 202, CreatedAt = DateTime.Now };
//            var updatedLike = new Like { LikeId = 1, LikedById = 105, LikedId = 205, CreatedAt = DateTime.Now };

//            _mockRepo.Setup(repo => repo.Get(existingLike.LikeId)).ReturnsAsync(existingLike);
//            _mockRepo.Setup(repo => repo.Update(updatedLike)).ReturnsAsync(updatedLike);

//            var result = await _likeService.Update(updatedLike);

//            Assert.NotNull(result);
//            Assert.AreEqual(updatedLike.LikeId, result.LikeId);
//            Assert.AreEqual(updatedLike.LikedById, result.LikedById);
//            Assert.AreEqual(updatedLike.LikedId, result.LikedId);
//        }

//        [Test]
//        public void UpdateLike_ThrowsNotFoundException_WhenEntityDoesNotExist()
//        {
//            var updatedLike = new Like { LikeId = 1, LikedById = 105, LikedId = 205, CreatedAt = DateTime.Now };

//            _mockRepo.Setup(repo => repo.Get(updatedLike.LikeId)).ReturnsAsync((Like)null);

//            Assert.ThrowsAsync<NotFoundException>(() => _likeService.Update(updatedLike));
//        }
//    }
//}
