using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Exceptions;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrimonialCapstoneTest.ServiceTest
{
    public class MemberServiceTest
    {
        private Mock<IRepository<int, Member>> _mockRepo;
        private MemberServices _memberServices;
        private MatrimonialContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MatrimonialContext>()
                .UseInMemoryDatabase(databaseName: "MatrimonialDatabase")
                .Options;
            _context = new MatrimonialContext(options);

            _context.Database.EnsureDeletedAsync().Wait();
            _context.Database.EnsureCreatedAsync().Wait();

            _mockRepo = new Mock<IRepository<int, Member>>();
            _memberServices = new MemberServices(_mockRepo.Object);
        }

        [Test]
        public async Task CreateMultiple_CreatesEntity()
        {
            var member = new Member { MemberId = 101, Name = "John Doe", Email = "John@gmail.com" };
            var member2 = new Member { MemberId = 102, Name = "John", Email = "Johnson@gmail.com" };

            _mockRepo.Setup(repo => repo.Create(member)).ReturnsAsync(member);
            _mockRepo.Setup(repo => repo.Create(member2)).ReturnsAsync(member2);

            IList<Member> memberlist = new List<Member>();
            memberlist.Add(member);
            memberlist.Add(member2);

            var result = await _memberServices.CreateMultiple(memberlist);

            Assert.NotNull(result);
            Assert.AreEqual(member.MemberId, result[0].MemberId);
        }

        [Test]
        public async Task Create_CreatesEntity()
        {
            var member = new Member { MemberId = 1, Name = "John Doe", Email = "John@gmail.com" };
            _mockRepo.Setup(repo => repo.Create(member)).ReturnsAsync(member);

            var result = await _memberServices.Create(member);

            Assert.NotNull(result);
            Assert.AreEqual(member.MemberId, result.MemberId);
        }

        [Test]
        public void Create_ThrowsUnableToCreateException_WhenEntityIsNull()
        {
            _mockRepo.Setup(repo => repo.Create(It.IsAny<Member>())).ReturnsAsync((Member)null);

            Assert.ThrowsAsync<UnableToCreateException>(() => _memberServices.Create(new Member()));
        }

        [Test]
        public async Task Delete_DeletesEntity()
        {
            var member = new Member { MemberId = 1, Name = "John Doe", Email = "John@gmail.com" };
            _mockRepo.Setup(repo => repo.Delete(member.MemberId)).ReturnsAsync(member);

            var result = await _memberServices.Delete(member.MemberId);

            Assert.NotNull(result);
            Assert.AreEqual(member.MemberId, result.MemberId);
        }

        [Test]
        public void Delete_ThrowsNotFoundException_WhenEntityIsNull()
        {
            _mockRepo.Setup(repo => repo.Delete(It.IsAny<int>())).ReturnsAsync((Member)null);

            Assert.ThrowsAsync<NotFoundException>(() => _memberServices.Delete(1));
        }

        [Test]
        public async Task GetAll_ReturnsAllEntities()
        {
            var members = new List<Member>
            {
                new Member { MemberId = 1, Name = "John Doe", Email = "John@gmail.com" },
                new Member { MemberId = 2, Name = "Jane Doe", Email = "Jane@gmail.com" }
            };

            _mockRepo.Setup(repo => repo.Get()).ReturnsAsync(members);

            var result = await _memberServices.GetAll();

            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetAll_ThrowsNotFoundException_WhenEntitiesAreNull()
        {
            _mockRepo.Setup(repo => repo.Get()).ReturnsAsync((IEnumerable<Member>)null);

            Assert.ThrowsAsync<NotFoundException>(() => _memberServices.GetAll());
        }

        [Test]
        public async Task GetById_ReturnsEntity()
        {
            var member = new Member { MemberId = 1, Name = "John Doe", Email = "John@gmail.com" };
            _mockRepo.Setup(repo => repo.Get(member.MemberId)).ReturnsAsync(member);

            var result = await _memberServices.GetById(member.MemberId);

            Assert.NotNull(result);
            Assert.AreEqual(member.MemberId, result.MemberId);
        }

    }
}
