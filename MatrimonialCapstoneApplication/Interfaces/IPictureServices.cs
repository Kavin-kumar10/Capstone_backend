using MatrimonialCapstoneApplication.Models.DTOs.RequestDTOs;

namespace MatrimonialCapstoneApplication.Interfaces
{
    public interface IPictureServices
    {
        public Task<IEnumerable<string>> UploadImage(ImageRequestDto imageRequestDto);
    }
}
