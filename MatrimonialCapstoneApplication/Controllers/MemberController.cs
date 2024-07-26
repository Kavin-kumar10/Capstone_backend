using MatrimonialCapstoneApplication.Exceptions;
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
        ILogger<MemberController> _logger;
        public MemberController(IServices<int,Member> services, ILogger<MemberController> logger)
        {
            _services = services;
            _logger = logger;
        }

        /// <summary>
        /// Get all the members details
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Member>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Member>>> GetAllMembers()
        {
            try
            {
                var result = await _services.GetAll();
                _logger.LogInformation("Get All Member Details");
                return Ok(result);
            }
            catch(NotFoundException nfe)
            {
                _logger.LogError("No such Members Found");
                return BadRequest(new ErrorModel(404,nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        /// <summary>
        /// Get Member details by Id
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Profile/{MemberId}")]
        [ProducesResponseType(typeof(Member), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Member>> GetmyProfile(int MemberId)
        {
            try
            {
                var result = await _services.GetById(MemberId);
                _logger.LogInformation("Get Member Details by Id");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Members Found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }


        /// <summary>
        /// Create new Member 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Member), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Member>> CreateNewMember(Member member)
        {
            try
            {
                var result = await _services.Create(member);
                _logger.LogInformation("Get Member Details by Id");
                return Ok(result);
            }
            catch (UnableToCreateException utce)
            {
                _logger.LogError("Unable to create");
                return BadRequest(new ErrorModel(404, utce.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        /// <summary>
        /// Update already existing member
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>

        [HttpPut]
        [ProducesResponseType(typeof(Member), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Member>> UpdateExistingMember(Member member)
        {
            try
            {
                var result = await _services.Update(member);
                _logger.LogInformation("Get Member Details by Id");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Members Found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        /// <summary>
        /// Delete member from the Database
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(Member), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Member>> DeleteExistingMember(int MemberId)
        {
            try
            {
                var result = await _services.Delete(MemberId);
                _logger.LogInformation("Get Member Details by Id");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Members Found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

    }
}
