using MatrimonialCapstoneApplication.Exceptions;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialCapstoneApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private IServices<int, Hobby> _services;
        ILogger<HobbyController> _logger;
        public HobbyController(IServices<int, Hobby> services, ILogger<HobbyController> logger)
        {
            _services = services;
            _logger = logger;
        }

        /// <summary>
        /// Get Hobby of all members
        /// </summary>
        /// <param name="HobbyId"></param>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Hobby>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Hobby>> GetHobby()
        {
            try
            {
                var result = await _services.GetAll();
                _logger.LogInformation("Getting all Hobby");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No Hobby found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        /// <summary>
        /// Get Hobby using HobbyId
        /// </summary>
        /// <param name="HobbyId"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Hobby), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Hobby>> GetHobbyWithId(int HobbyId)
        {
            try
            {
                var result = await _services.GetById(HobbyId);
                _logger.LogInformation("Getting Hobby using Id");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Hobby Found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        /// <summary>
        /// Create new Hobby for a member
        /// </summary>
        /// <param name="Hobby"></param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(typeof(Hobby), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Hobby>> PostHobby(Hobby Hobby)
        {
            try
            {
                var result = await _services.Create(Hobby);
                _logger.LogInformation("Created new Hobby");
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
        /// Update already existing Hobby
        /// </summary>
        /// <param name="Hobby"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Hobby), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Hobby>> UpdateHobby(Hobby Hobby)
        {
            try
            {
                var result = await _services.Update(Hobby);
                _logger.LogInformation("Updating Hobby");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Hobby Found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        /// <summary>
        /// Delete already existing Hobby
        /// </summary>
        /// <param name="Hobby"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(Hobby), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Hobby>> DeleteHobby(int HobbyId)
        {
            try
            {
                var result = await _services.Delete(HobbyId);
                _logger.LogInformation("Delete Hobby with id");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Hobby Found");
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
