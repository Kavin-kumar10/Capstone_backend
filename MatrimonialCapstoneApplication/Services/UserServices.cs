using EcommerceApplication.Models.DTOs.RequestDTOs;
using EcommerceApplication.Models.DTOs.ReturnDTOs;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Models;
using MatrimonialCapstoneApplication.Models.Enums;
using System.Security.Cryptography;
using System.Text;

namespace MatrimonialCapstoneApplication.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<int, User> _repo;
        private readonly IRepository<int, Member> _memRepo;
        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService;
        private readonly IRepository<int, PersonalDetails> _personalRepo;

        public UserServices(IRepository<int, User> repo, IRepository<int, Member> memRepo, IUserRepository userRepository, ITokenService tokenService,IRepository<int,PersonalDetails> personalRepo)
        {
            _repo = repo;
            _memRepo = memRepo;
            _userRepo = userRepository;
            _tokenService = tokenService;
            _personalRepo = personalRepo;
        }
        public async Task<LoginReturnDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = await _userRepo.Get(loginRequestDTO.Email);
            if (user == null) { throw new Exception("User not found"); }
            HMACSHA512 hMACSHA512 = new HMACSHA512(user.HashedPassword);
            var encryptedpass = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(loginRequestDTO.Password));
            bool isPass = ComparePassword(encryptedpass, user.Password);
            if (isPass)
            {
                var member = await _memRepo.Get(user.MemberId);
                if (user.Status == "Active")
                {
                    var loginreturn = MapMemberToLoginReturn(loginRequestDTO, member);
                    return loginreturn;
                }
                throw new Exception("User is disabled");
            }
            throw new Exception("Password missmatched");
        }

        public LoginReturnDTO MapMemberToLoginReturn(LoginRequestDTO loginRequestDTO, Member member)
        {
            LoginReturnDTO loginReturnDTO = new LoginReturnDTO();
            loginReturnDTO.MemberId = member.MemberId.ToString();
            loginReturnDTO.Role = member.Role;
            loginReturnDTO.Token = _tokenService.GenerateToken(member);
            return loginReturnDTO;
        }

        private bool ComparePassword(Byte[] loginPass, Byte[] password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (loginPass[i] != password[i]) return false;
            }
            return true;
        }

        public async Task<User> Register(RegisterRequestDTO registerRequestDTO)
        {

            User user = new User();
            Member member = new Member();
            PersonalDetails personalDetails = new PersonalDetails();
            var users = await _repo.Get();
            if (users.FirstOrDefault(u => u.Email == registerRequestDTO.Email) != null)
            {
                throw new Exception("Member Already found");
            }
            try
            {
                user = await MapDTOtoUser(registerRequestDTO);
                member.Email = registerRequestDTO.Email;
                member.Name = registerRequestDTO.Name;
                member.Role = RoleEnum.User;
                var newMember = await _memRepo.Create(member);
                if (newMember == null)
                {
                    throw new Exception("Not created");
                }
                personalDetails.MemberId = newMember.MemberId;
                user.MemberId = newMember.MemberId;
                user.Name = newMember.Name;
                var newUser = await _repo.Create(user);
                var newPersonalDetails = await _personalRepo.Create(personalDetails);
                if (newUser == null)
                {
                    await _memRepo.Delete(user.MemberId);
                    throw new Exception("Not created");
                }
                return newUser;
            }
            catch (Exception ex) { }
            throw new Exception("Unable to register exception");
        }

        private async Task<User> MapDTOtoUser(RegisterRequestDTO registerRequestDTO)
        {
            User user = new User();
            HMACSHA512 hMACSHA512 = new HMACSHA512();
            user.Email = registerRequestDTO.Email;
            user.HashedPassword = hMACSHA512.Key;
            user.Password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(registerRequestDTO.Password));
            return user;
        }


    }
}
