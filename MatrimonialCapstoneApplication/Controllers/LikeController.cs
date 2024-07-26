using MatrimonialCapstoneApplication.Exceptions;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialCapstoneApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private IServices<int, Like> _services;
        ILogger<LikeController> _logger;
        public LikeController(IServices<int, Like> services, ILogger<LikeController> logger)
        {
            _services = services;
            _logger = logger;
        }

        /// <summary>
        /// Get Like of all members
        /// </summary>
        /// <param name="LikeId"></param>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Like>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Like>> GetLike()
        {
            try
            {
                var result = await _services.GetAll();
                _logger.LogInformation("Getting all Like");
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
        /// Get Like using LikeId
        /// </summary>
        /// <param name="LikeId"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Like), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Like>> GetLikeWithId(int LikeId)
        {
            try
            {
                var result = await _services.GetById(LikeId);
                _logger.LogInformation("Getting Like using Id");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Like Found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        /// <summary>
        /// Create new Like for a member
        /// </summary>
        /// <param name="Like"></param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(typeof(Like), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Like>> PostLike(Like Like)
        {
            try
            {
                var result = await _services.Create(Like);
                _logger.LogInformation("Created new Like");
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
        /// Update already existing Like
        /// </summary>
        /// <param name="Like"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Like), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Like>> UpdateLike(Like Like)
        {
            try
            {
                var result = await _services.Update(Like);
                _logger.LogInformation("Updating Like");
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
        /// Delete already existing Like
        /// </summary>
        /// <param name="Like"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(Like), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Like>> DeleteLike(int LikeId)
        {
            try
            {
                var result = await _services.Delete(LikeId);
                _logger.LogInformation("Delete Like with id");
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
