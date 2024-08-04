using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Models;
using MatrimonialCapstoneApplication.Models.Enums;
using MatrimonialCapstoneApplication.Repositories;
using MatrimonialCapstoneApplication.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MatrimonialCapstoneTest.ServiceTest
{
    public class ActivateServiceTest
    {
        MatrimonialContext _context;
        private IRepository<int, Member> _MemberRepo;
        private IRepository<int, User> _UserRepo;
        private IRepository<int, DailyLog> _dailyLogRepo;
        IActivateServices _service;


        [SetUp]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<MatrimonialContext>()
         .UseInMemoryDatabase(databaseName: "MatrimonialDatabase")
         .Options;
            _context = new MatrimonialContext(options);
            _context.Database.EnsureDeletedAsync().Wait();
            _context.Database.EnsureCreatedAsync().Wait();
            _MemberRepo = new MemberRepository(_context);
            _UserRepo = new UserRepository(_context);
            _dailyLogRepo = new DailyLogsRepository(_context);
            _service = new ActivateServices(_UserRepo, _MemberRepo,_dailyLogRepo);


            Member member = new Member()
            {
                Email = "Raja@gmail.com",
                Membership = Membershipenum.Free,
                Name = "Raja",
                Role = RoleEnum.User,
            };
            await _MemberRepo.Create(member);
            User user = new User()
            {
                MemberId = 1,
                Email = "Raja@gmail.com",
                Name = "Raja",
                Password = Encoding.UTF8.GetBytes("yourPassword"),
                HashedPassword = Encoding.UTF8.GetBytes("yourPassword"),
                Status = "Disable"
            };
            await _UserRepo.Create(user);
        }

        [Test]
        public async Task Activate_User_PassTest()
        {
            var result = await _service.Activate(1, RoleEnum.User, Membershipenum.Free);
            Console.Write(result.Status);
            Assert.That(result.Status, Is.EqualTo("Active"));
        }

        [Test]
        public async Task Deactivate_User_PassTest()
        {
            var result = await _service.Deactivate(1);
            Console.Write(result.Status);
            Assert.That(result.Status, Is.EqualTo("Disabled"));
        }

        [Test]
        public async Task Activate_User_FailTest()
        {
            try
            {
                var result = await _service.Activate(10, RoleEnum.User, Membershipenum.Free);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("User not Found"));
            }
        }

        [Test]
        public async Task Deactivate_User_FailTest()
        {
            try
            {
                var result = await _service.Deactivate(2);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("User not Found"));
            }
        }
    }
}
