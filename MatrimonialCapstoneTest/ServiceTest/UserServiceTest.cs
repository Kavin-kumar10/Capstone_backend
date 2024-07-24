//using EcommerceApplication.Models.DTOs.RequestDTOs;
//using MatrimonialCapstoneApplication.Context;
//using MatrimonialCapstoneApplication.Exceptions.ActivationExceptions;
//using MatrimonialCapstoneApplication.Exceptions.AuthExceptions;
//using MatrimonialCapstoneApplication.Interfaces;
//using MatrimonialCapstoneApplication.Modals;
//using MatrimonialCapstoneApplication.Repositories;
//using MatrimonialCapstoneApplication.Services;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MatrimonialCapstoneTest.ServiceTest
//{
//    public class UserServiceTest
//    {
//        MatrimonialContext context;
//        ITokenService _tokenServices;
//        IRepository<int, Member> _memRepo;
//        IRepository<int, User> _userRepo;
//        IUserServices _services;

//        [SetUp]
//        public async Task Setup()
//        {
//            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder()
//                                .UseInMemoryDatabase("dummyDB");
//            context = new MatrimonialContext(optionsBuilder.Options);

//            context.Database.EnsureDeletedAsync().Wait();
//            context.Database.EnsureCreatedAsync().Wait();

//            //Token Services

//            Mock<IConfigurationSection> configurationJWTSection = new Mock<IConfigurationSection>();
//            configurationJWTSection.Setup(x => x.Value).Returns("This is the dummy key which has to be a bit long for the 512. which should be even more longer for the passing");
//            Mock<IConfigurationSection> congigTokenSection = new Mock<IConfigurationSection>();
//            congigTokenSection.Setup(x => x.GetSection("JWT")).Returns(configurationJWTSection.Object);
//            Mock<Iconfiguration> mockConfig = new Mock<Iconfiguration>();
//            mockConfig.Setup(x => x.GetSection("TokenKey")).Returns(congigTokenSection.Object);
//            _tokenServices = new TokenServices(mockConfig.Object);

//            // Initial Setup
//            _memRepo = new MemberRepository(context);
//            _userRepo = new UserRepository(context);
//            _services = new UserServices(_memRepo, _userRepo, _tokenServices);

//            //Demo User
//            //Arrange
//            RegisterRequestDTO registerDTO = new RegisterRequestDTO();
//            registerDTO.Email = "Pravinkumar.prof@gmail.com";
//            registerDTO.Name = "Pravin";
//            registerDTO.Password = "Pravin@25";

//            //Action
//            var result = await _services.Register(registerDTO);
//        }

//        [Test]
//        public async Task Register_PassTest()
//        {
//            //Arrange
//            RegisterRequestDTO registerDTO = new RegisterRequestDTO();
//            registerDTO.Email = "kavin.prof@gmail.com";
//            registerDTO.Name = "Kavin";
//            registerDTO.Password = "Kavin@10";

//            //Action
//            var result = await _services.Register(registerDTO);

//            //Assert
//            Assert.That(result.MemberId, Is.EqualTo(105));
//            Assert.That(result.Email, Is.EqualTo("kavin.prof@gmail.com"));
//            Assert.That(result.Name, Is.EqualTo("Kavin"));
//        }

//        [Test]
//        public async Task Register_FailTest()
//        {
//            //Arrange
//            try
//            {

//                RegisterRequestDTO registerDTO = new RegisterRequestDTO();
//                registerDTO.Email = "kavin.prof@gmail.com";
//                registerDTO.Name = "Kavin";
//                //registerDTO.password = "Kavin@10";

//                //Action
//                var result = await _services.Register(registerDTO);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//                Assert.That(ex.Message, Is.EqualTo("Unable to Register"));
//            }
//        }

//        [Test]
//        public async Task Register_duplicateMailId_FailTest()
//        {
//            //Arrange
//            try
//            {

//                RegisterRequestDTO registerDTO = new RegisterRequestDTO();
//                registerDTO.Email = "kavinkumar.prof@gmail.com";
//                registerDTO.Name = "Kavin";
//                registerDTO.Password = "Kavin@10";

//                //Action
//                var result = await _services.Register(registerDTO);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//                Assert.That(ex.Message, Is.EqualTo("Member with the Id Already Found"));
//            }
//        }

//        [Test]
//        public async Task Login_AccountNotActivatedException_PassTest()
//        {
//            //Arrange
//            try
//            {

//                LoginRequestDTO userLoginDTO = new LoginRequestDTO();
//                userLoginDTO.Email = "Kavinkumar.prof@gmail.com";
//                userLoginDTO.Password = "Pravin@25";

//                //Action
//                var result = await _services.Login(userLoginDTO);
//            }
//            catch (UserNotActiveException unae)
//            {
//                Assert.That(unae.Message, Is.EqualTo("Your account is not activated"));
//                Console.WriteLine(unae.Message);
//            }
//        }

//        [Test]
//        public async Task Login_FailTest()
//        {
//            //Arrange
//            try
//            {

//                LoginRequestDTO userLoginDTO = new LoginRequestDTO();
//                userLoginDTO.Email = "Kavinkumar.prof@gmail.com";
//                userLoginDTO.Password = "Pravin@25";

//                //Action
//                var result = await _services.Login(userLoginDTO);
//            }
//            catch (UnauthorizedUserException uaue)
//            {
//                Assert.That(uaue.Message, Is.EqualTo("Invalid username or password"));
//                Console.WriteLine(uaue.Message);
//            }
//        }
//    }
//}
