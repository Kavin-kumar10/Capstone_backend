using MatrimonialCapstoneApplication.Models.DTOs.ReturnDTOs;
using MatrimonialCapstoneApplication.Models.Enums;
using System.Numerics;

namespace MatrimonialCapstoneApplication.Interfaces
{
    public interface IActivateServices
    {
        public Task<ActivateReturnDTO> Activate(int MemberId, RoleEnum Role, Membershipenum plan);
        public Task<ActivateReturnDTO> Deactivate(int MemberId);
    }
}
