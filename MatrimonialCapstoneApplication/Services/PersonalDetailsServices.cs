using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Services
{
    public class PersonalDetailsServices : BaseServices<PersonalDetails>, IPersonalDetailServices
    {
        IRepository<int,PersonalDetails> _repository;
        public PersonalDetailsServices(IRepository<int, PersonalDetails> repo) : base(repo)
        {
            _repository = repo; 
        }

        public async Task<PersonalDetails> GetPersonalDetailsWithMemberId(int MemberId)
        {
            var details =await _repository.Get();
            var result = details.FirstOrDefault(d=>d.MemberId == MemberId);
            return result;
            throw new NotImplementedException();
        }
    }
}
