using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MatrimonialCapstoneApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        IDailyLogServices _Services;
        IServices<int, Member> _memberServices;
        public ValidateController(IDailyLogServices services,IServices<int,Member> memberServices) {
            _Services = services;
            _memberServices = memberServices;
        }

        [HttpGet("validate-token")]
        public async Task<IActionResult> ValidateTokenAnonymous()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var memberId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                    var member = await _memberServices.GetById(int.Parse(memberId));
                    if(member.Membership == Models.Enums.Membershipenum.Premium)
                    {
                        await _Services.RefreshCount(int.Parse(memberId));
                    }
                    return Ok(new { Authorized = true });
                }
                else
                {
                    return Unauthorized(new { Authorized = false });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorModel(500,e.Message));
            }
        }
    }
}
