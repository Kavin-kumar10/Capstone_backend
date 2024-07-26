using MatrimonialCapstoneApplication.Exceptions;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialCapstoneApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocateController : ControllerBase
    {
        private IServices<int, Locate> _services;
        ILogger<LocateController> _logger;
        public LocateController(IServices<int, Locate> services, ILogger<LocateController> logger)
        {
            _services = services;
            _logger = logger;
        }

        /// <summary>
        /// Get Locate of all members
        /// </summary>
        /// <param name="LocateId"></param>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Locate>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Locate>> GetLocate()
        {
            try
            {
                var result = await _services.GetAll();
                _logger.LogInformation("Getting all Locate");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No Locate found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        /// <summary>
        /// Get Locate using LocateId
        /// </summary>
        /// <param name="LocateId"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Locate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Locate>> GetLocateWithId(int LocateId)
        {
            try
            {
                var result = await _services.GetById(LocateId);
                _logger.LogInformation("Getting Locate using Id");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Locate Found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        /// <summary>
        /// Create new Locate for a member
        /// </summary>
        /// <param name="Locate"></param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(typeof(Locate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Locate>> PostLocate(Locate Locate)
        {
            try
            {
                var result = await _services.Create(Locate);
                _logger.LogInformation("Created new Locate");
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
        /// Update already existing Locate
        /// </summary>
        /// <param name="Locate"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Locate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Locate>> UpdateLocate(Locate Locate)
        {
            try
            {
                var result = await _services.Update(Locate);
                _logger.LogInformation("Updating Locate");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Locate Found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        /// <summary>
        /// Delete already existing Locate
        /// </summary>
        /// <param name="Locate"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(Locate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Locate>> DeleteLocate(int LocateId)
        {
            try
            {
                var result = await _services.Delete(LocateId);
                _logger.LogInformation("Delete Locate with id");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Locate Found");
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
