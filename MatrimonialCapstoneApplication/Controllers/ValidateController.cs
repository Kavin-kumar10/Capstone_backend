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
        ILogger<ValidateController> _logger;
        public ValidateController(IDailyLogServices services,IServices<int,Member> memberServices,ILogger<ValidateController> logger) {
            _Services = services;
            _memberServices = memberServices;
            _logger = logger;
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
                    if (member.Role == Models.Enums.RoleEnum.Admin)
                    {
                        _logger.LogInformation("Admin authenticated");
                        return Ok(new { Authorized = true, role = "admin" });
                    }
                    else
                    {
                        _logger.LogInformation("User authenticated");
                        return Ok(new { Authorized = true, role = "user" });
                    }
                }
                else
                {
                    _logger.LogInformation("User unAuthorized");
                    return Unauthorized(new { Authorized = false });
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(new ErrorModel(500,e.Message));
            }
        }
    }
}
