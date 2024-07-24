using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Services
{
    public class PictureServices : BaseServices<Picture>
    {
        public PictureServices(IRepository<int, Picture> repo) : base(repo)
        {
        }
    }
}
