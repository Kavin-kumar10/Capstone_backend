using MatrimonialCapstoneApplication.Exceptions.AuthExceptions;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Models;
using MatrimonialCapstoneApplication.Models.DTOs.ReturnDTOs;
using MatrimonialCapstoneApplication.Models.Enums;
using System.Numerics;

namespace MatrimonialCapstoneApplication.Services
{
    public class ActivateServices : IActivateServices
    {
        private IRepository<int, User> _userRepo;
        private IRepository<int, Member> _memRepo;
        private IRepository<int, DailyLog> _dailyRepo;

        #region Constructor
        public ActivateServices(IRepository<int, User> userrepo, IRepository<int, Member> memRepo,IRepository<int,DailyLog> dailyRepo)
        {
            _userRepo = userrepo;
            _memRepo = memRepo;
            _dailyRepo = dailyRepo;
        }
        #endregion

        #region Activate Member (Only by Admin)
        /// <summary>
        /// Activate The User based on Role and Plan -> Access -> Admin
        /// </summary>
        /// <param name="MemberId"></param>
        /// <param name="Role"></param>
        /// <param name="plan"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>

        public async Task<ActivateReturnDTO> Activate(int MemberId, RoleEnum Role, Membershipenum plan)
        {
            ActivateReturnDTO returnDTO = new ActivateReturnDTO();
            var reqUser = await _userRepo.Get(MemberId); // Activating Member
            var reqMember = await _memRepo.Get(MemberId); // Providing Role and Plan to Member
            if (reqUser == null || reqMember == null)
                throw new UserNotFoundException();
            if (reqMember != null)
            {
                if(plan == Membershipenum.Premium)
                {
                    DailyLog newDailylog = new DailyLog();
                    newDailylog.CreditsCount = 5;
                    newDailylog.Date = new DateTime();
                    newDailylog.Member = reqMember;
                    newDailylog.MemberId = MemberId;
                    var result = await _dailyRepo.Create(newDailylog);
                    reqMember.DailyLog = result;
                }
                reqMember.Role = Role;
                reqMember.Membership = plan;
                await _memRepo.Update(reqMember);
                returnDTO.Role = Role;
                returnDTO.Membership = plan;
            }
            if (reqUser != null)
            {
                reqUser.Status = "Active";
                var res = await _userRepo.Update(reqUser);
                returnDTO.Id = res.MemberId;
                returnDTO.Status = res.Status;
                return returnDTO;
            }
            throw new UserNotFoundException();
        }
        #endregion

        #region Deactivate Member (Only by Admin)
        /// <summary>
        /// Deactivate User with memberid parameter Access -> only Admin
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        public async Task<ActivateReturnDTO> Deactivate(int MemberId)
        {
            ActivateReturnDTO returnDTO = new ActivateReturnDTO();
            var reqUser = await _userRepo.Get(MemberId);
            var reqMember = await _memRepo.Get(MemberId);
            if (reqUser != null && reqMember != null)
            {
                reqUser.Status = "Disabled";
                var res = await _userRepo.Update(reqUser);
                returnDTO.Id = res.MemberId;
                returnDTO.Status = res.Status;
                returnDTO.Role = reqMember.Role;
                return returnDTO;
            }
            throw new UserNotFoundException();
        }
        #endregion
    }
}
