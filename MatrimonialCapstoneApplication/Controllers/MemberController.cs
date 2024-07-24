using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialCapstoneApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IServices<int, Member> _services;

        public MemberController(IServices<int,Member> services)
        {
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Member>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Member>>> GetAllMembers()
        {
            try
            {
                var result = await _services.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(404, ex.Message));
            }
        }


        [HttpGet]
        [Route("Profile")]
        [ProducesResponseType(typeof(Member), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Member>> GetmyProfile(int MemberId)
        {
            try
            {
                var result = await _services.GetById(MemberId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(404, ex.Message));
            }
        }


    }
}
