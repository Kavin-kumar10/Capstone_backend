using MatrimonialCapstoneApplication.Exceptions.AuthExceptions;
using MatrimonialCapstoneApplication.Exceptions.SubscriptionException;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Services
{
    public class PersonalDetailsServices : BaseServices<PersonalDetails>, IPersonalDetailServices
    {
        IRepository<int,PersonalDetails> _repository;
        IRepository<int, Member> _memberRepo;
        IMemberRepository _memberRepository;
        IRepository<int, DailyLog> _dailyRepo;
        public PersonalDetailsServices(IRepository<int, PersonalDetails> repo,IRepository<int,Member> memberRepo,IMemberRepository memberRepository,IRepository<int,DailyLog> dailyRepo) : base(repo)
        {
            _repository = repo; 
            _memberRepo = memberRepo;
            _memberRepository = memberRepository;
            _dailyRepo = dailyRepo;
        }

        public async Task<PersonalDetails> GetPersonalDetailsWithMemberId(int MemberId, string Email, string Role)
        {
            var member = await _memberRepo.Get(MemberId);
            var requestedMember = await _memberRepository.Get(Email);
            Console.WriteLine(Role);
            if (member == null || requestedMember == null)
            {
                throw new UserNotFoundException();
            }
            else
            {
                if(requestedMember.Membership == Models.Enums.Membershipenum.Premium || member.Email == Email)
                {
                    var dailyLogOfRequestedMember = requestedMember.DailyLog;
                    if(dailyLogOfRequestedMember.CreditsCount == 0 && member.Email != Email)
                    {
                        throw new OutOfCreditsException();
                    }
                    var details =await _repository.Get();
                    dailyLogOfRequestedMember.CreditsCount -= 1;
                    await _dailyRepo.Update(dailyLogOfRequestedMember);
                    var result = details.FirstOrDefault(d=>d.MemberId == MemberId);
                    return result;
                }
                if(requestedMember.Membership == Models.Enums.Membershipenum.Free)
                {
                    throw new NoPremiumSubscriptionException();
                }
            }
            throw new NotImplementedException();
        }

        public async Task<PersonalDetails> GetPersonalDetailsWithToken(int MemberId)
        {
            var details = await _repository.Get();
            var result = details.FirstOrDefault(d=>d.MemberId == MemberId);
            return result;
        }
    }
}
