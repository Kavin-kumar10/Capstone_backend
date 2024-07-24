using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Diagnostics.Metrics;


namespace MatrimonialCapstoneTest.RepositoryTest
{
    public class MemberRepositoryTests
    {
        private MatrimonialContext _context;
        private IRepository<int,Member> _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MatrimonialContext>()
                .UseInMemoryDatabase(databaseName: "MatrimonialDatabase")
                .Options;
            _context = new MatrimonialContext(options);

            _context.Database.EnsureDeletedAsync().Wait();
            _context.Database.EnsureCreatedAsync().Wait();

            _repository = new MemberRepository(_context);

        }

        [Test]
        public async Task Create_AddsEntityToContext()
        {
            var member = new Member { MemberId = 1, Name = "John Doe", Email = "John@gmail.com" };

            await _repository.Create(member);

            var result = await _repository.Get(member.MemberId);

            Assert.NotNull(result);
            Assert.AreEqual(member.MemberId, result.MemberId);
        }

        [Test]
        public async Task Delete_RemovesEntityFromContext()
        {
            var member = new Member { MemberId = 1, Name = "John Doe", Email = "John@gmail.com" };
            await _repository.Create(member);

            var deletedMember = await _repository.Delete(member.MemberId);

            var result = await _repository.Get(member.MemberId);

            Assert.IsNull(result);
            Assert.AreEqual(member.MemberId, deletedMember.MemberId);
        }

        [Test]
        public async Task GetAll_ReturnsAllEntities()
        {
            var members = new List<Member>
            {
                new Member { MemberId = 1, Name = "John Doe", Email = "John@gmail.com" },
                new Member { MemberId = 2, Name = "Jane Doe", Email = "John@gmail.com" }
            };

            foreach (var member in members)
            {
                await _repository.Create(member);
            }

            var result = await _repository.Get();

            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task Update_UpdatesEntityInContext()
        {
            var member = new Member { MemberId = 1, Name = "John Doe", Email = "John@gmail.com" };
            await _repository.Create(member);

            member.Name = "John Updated";
            var updatedMember = await _repository.Update(member);

            var result = await _repository.Get(updatedMember.MemberId);

            Assert.NotNull(result);
            Assert.AreEqual("John Updated", result.Name);
        }
    }
}