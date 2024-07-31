using MatrimonialCapstoneApplication.Exceptions;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MatrimonialCapstoneApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDetailsController : ControllerBase
    {
        private IServices<int, PersonalDetails> _services;
        private IPersonalDetailServices _personaldetailservices;
        ILogger<PersonalDetailsController> _logger;
        public PersonalDetailsController(IServices<int,PersonalDetails> services, ILogger<PersonalDetailsController> logger, IPersonalDetailServices personaldetailservices)
        {
            _services = services;
            _logger = logger;
            _personaldetailservices = personaldetailservices;
        }


        [HttpGet]
        [Route("GetPersonalDetailByToken")]
        [Authorize]
        [ProducesResponseType(typeof(PersonalDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonalDetails>> GetPersonalDetailsWithId()
        {
            try
            {
                var memberId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var result = await _personaldetailservices.GetPersonalDetailsWithToken(int.Parse(memberId));
                _logger.LogInformation("Getting personal Details using Id");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Person Found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        /// <summary>
        /// Get Personal Details of all members
        /// </summary>
        /// <param name="PersonalDetailsId"></param>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PersonalDetails>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonalDetails>> GetPersonalDetails()
        {
            try
            {
                var result = await _services.GetAll();
                _logger.LogInformation("Getting all personal details");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No member found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        /// <summary>
        /// Get Personal Details using PersonalDetailId
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>

        [HttpGet]
        [Authorize]
        [Route("GetByMemberId")]
        [ProducesResponseType(typeof(PersonalDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonalDetails>> GetPersonalDetailsWithMemId(int MemberId)
        {
            try
            {
                // Extract the email from the Name claim
                var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

                // Extract the role from the Role claim
                var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                _logger.LogCritical(userEmail);
                _logger.LogCritical(userRole);
                var result = await _personaldetailservices.GetPersonalDetailsWithMemberId(MemberId,userEmail,userRole);
                _logger.LogInformation("Getting personal Details using Id");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Person Found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        /// <summary>
        /// Get Personal Details using PersonalDetailId
        /// </summary>
        /// <param name="PersonalDetailsId"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(PersonalDetails),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonalDetails>> GetPersonalDetailsWithId(int PersonalDetailsId)
        {
            try
            {
                var result = await _services.GetById(PersonalDetailsId);
                _logger.LogInformation("Getting personal Details using Id");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Person Found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        /// <summary>
        /// Create new PersonalDetail for a member
        /// </summary>
        /// <param name="personalDetails"></param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(typeof(PersonalDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonalDetails>> PostPersonalDetail(PersonalDetails personalDetails)
        {
            try
            {
                var result = await _services.Create(personalDetails);
                _logger.LogInformation("Created new person detail");
                return Ok(result);
            }
            catch (UnableToCreateException utce)
            {
                _logger.LogError("Unable to Create exception");
                return BadRequest(new ErrorModel(500, utce.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }


        /// <summary>
        /// Update already existing Personal details
        /// </summary>
        /// <param name="personalDetails"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(PersonalDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonalDetails>> UpdatePersonalDetail(PersonalDetails personalDetails)
        {
            try
            {
                var result = await _services.Update(personalDetails);
                _logger.LogInformation("Updating Personal Details");
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
        /// Delete already existing personal details
        /// </summary>
        /// <param name="personalDetails"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(PersonalDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonalDetails>> DeletePersonalDetail(int personalDetailsId)
        {
            try
            {
                var result = await _services.Delete(personalDetailsId);
                _logger.LogInformation("Delete personal details with id");
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
