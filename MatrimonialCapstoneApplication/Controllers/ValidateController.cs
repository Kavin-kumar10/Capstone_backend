using MatrimonialCapstoneApplication.Interfaces;
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
        public ValidateController(IDailyLogServices services) {
            _Services = services;
        }

        [HttpGet("validate-token")]
        public async Task<IActionResult> ValidateTokenAnonymous()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var memberId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                    await _Services.RefreshCount(int.Parse(memberId));
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
