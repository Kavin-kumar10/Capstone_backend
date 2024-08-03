using MatrimonialCapstoneApplication.Exceptions.AuthExceptions;
using MatrimonialCapstoneApplication.Exceptions.SubscriptionException;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Models;
using MatrimonialCapstoneApplication.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrimonialCapstoneTest.ServiceTest
{
    public class PersonalDetailsServiceTest
    {
        private readonly Mock<IRepository<int, PersonalDetails>> _repositoryMock;
        private readonly Mock<IRepository<int, Member>> _memberRepoMock;
        private readonly Mock<IMemberRepository> _memberRepositoryMock;
        private readonly Mock<IRepository<int, DailyLog>> _dailyRepoMock;
        private readonly Mock<IMatchesServices> _matchesServicesMock;
        private readonly PersonalDetailsServices _personalDetailsServices;

        public PersonalDetailsServiceTest()
        {
            _repositoryMock = new Mock<IRepository<int, PersonalDetails>>();
            _memberRepoMock = new Mock<IRepository<int, Member>>();
            _memberRepositoryMock = new Mock<IMemberRepository>();
            _dailyRepoMock = new Mock<IRepository<int, DailyLog>>();
            _matchesServicesMock = new Mock<IMatchesServices>();

            _personalDetailsServices = new PersonalDetailsServices(
                _repositoryMock.Object,
                _memberRepoMock.Object,
                _memberRepositoryMock.Object,
                _dailyRepoMock.Object,
                _matchesServicesMock.Object
            );
        }

        [Test]
        public async Task GetPersonalDetailsWithMemberId_ShouldReturnPersonalDetails_WhenMatchedProfileExists()
        {
            // Arrange
            var memberId = 1;
            var email = "test@example.com";
            var role = "User";
            var member = new Member { MemberId = memberId, Email = email, Membership = MatrimonialCapstoneApplication.Models.Enums.Membershipenum.Premium };
            var requestedMember = new Member { MemberId = 2, Email = email, Membership = MatrimonialCapstoneApplication.Models.Enums.Membershipenum.Premium, DailyLog = new DailyLog { CreditsCount = 5 } };
            var matchDetails = new[] { new MatrimonialCapstoneApplication.Models.Match { FromProfileId = 2, ToProfileId = 1, Status = "Matched" } };
            var personalDetails = new PersonalDetails { MemberId = memberId };

            _memberRepoMock.Setup(m => m.Get(memberId)).ReturnsAsync(member);
            _memberRepositoryMock.Setup(m => m.Get(email)).ReturnsAsync(requestedMember);
            _matchesServicesMock.Setup(m => m.GetMatchesWithMemberId(requestedMember.MemberId)).ReturnsAsync(matchDetails);
            _repositoryMock.Setup(r => r.Get()).ReturnsAsync(new[] { personalDetails }.AsQueryable());

            // Act
            var result = await _personalDetailsServices.GetPersonalDetailsWithMemberId(memberId, email, role);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(personalDetails.MemberId, result.MemberId);
        }

        [Test]
        public async Task GetPersonalDetailsWithMemberId_ShouldThrowUserNotFoundException_WhenMemberDoesNotExist()
        {
            // Arrange
            var memberId = 1;
            var email = "test@example.com";
            var role = "User";

            _memberRepoMock.Setup(m => m.Get(memberId)).ReturnsAsync((Member)null);
            _memberRepositoryMock.Setup(m => m.Get(email)).ReturnsAsync((Member)null);

            // Act & Assert
             Assert.ThrowsAsync<UserNotFoundException>(() => _personalDetailsServices.GetPersonalDetailsWithMemberId(memberId, email, role));
        }

        [Test]
        public async Task GetPersonalDetailsWithMemberId_ShouldThrowOutOfCreditsException_WhenNoCreditsAvailable()
        {
            // Arrange
            var memberId = 1;
            var email = "test@example.com";
            var role = "User";
            var member = new Member { MemberId = memberId, Email = "another@example.com" };
            var requestedMember = new Member { MemberId = 2, Email = email, Membership = MatrimonialCapstoneApplication.Models.Enums.Membershipenum.Premium, DailyLog = new DailyLog { CreditsCount = 0 } };

            _memberRepoMock.Setup(m => m.Get(memberId)).ReturnsAsync(member);
            _memberRepositoryMock.Setup(m => m.Get(email)).ReturnsAsync(requestedMember);

            // Act & Assert
             Assert.ThrowsAsync<OutOfCreditsException>(() => _personalDetailsServices.GetPersonalDetailsWithMemberId(memberId, email, role));
        }

        [Test]
        public async Task GetPersonalDetailsWithMemberId_ShouldThrowNoPremiumSubscriptionException_WhenRequestedMemberIsFree()
        {
            // Arrange
            var memberId = 1;
            var email = "test@example.com";
            var role = "User";
            var member = new Member { MemberId = memberId, Email = "another@example.com" };
            var requestedMember = new Member { MemberId = 2, Email = email, Membership = MatrimonialCapstoneApplication.Models.Enums.Membershipenum.Free };
            
            _memberRepoMock.Setup(m => m.Get(memberId)).ReturnsAsync(member);
            _memberRepositoryMock.Setup(m => m.Get(email)).ReturnsAsync(requestedMember);

            // Act & Assert
            Assert.ThrowsAsync<NoPremiumSubscriptionException>(() => _personalDetailsServices.GetPersonalDetailsWithMemberId(memberId, email, role));
        }

        [Test]
        public async Task GetPersonalDetailsWithToken_ShouldReturnPersonalDetails_WhenFound()
        {
            // Arrange
            var memberId = 1;
            var personalDetails = new PersonalDetails { MemberId = memberId };

            _repositoryMock.Setup(r => r.Get()).ReturnsAsync(new[] { personalDetails }.AsQueryable());

            // Act
            var result = await _personalDetailsServices.GetPersonalDetailsWithToken(memberId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(personalDetails.MemberId, result.MemberId);
        }
    }
}
