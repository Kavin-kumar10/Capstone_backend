using MatrimonialCapstoneApplication.Exceptions;
using MatrimonialCapstoneApplication.Exceptions.LikeDuplicateExceptions;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;
using MatrimonialCapstoneApplication.Models.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MatrimonialCapstoneApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private IServices<int, Like> _services;
        private ILikeServices _likeServices;
        ILogger<LikeController> _logger;
        public LikeController(IServices<int, Like> services, ILogger<LikeController> logger, ILikeServices likeServices)
        {
            _services = services;
            _logger = logger;
            _likeServices = likeServices;
        }

        #region Base services

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
        [Authorize]
        [ProducesResponseType(typeof(Like), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Like>> PostLike(int LikeMemberId)
        {

            try
            {
                var memberId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                //LikesPostRequestDto likesPostRequestDto = new LikesPostRequestDto();
                //likesPostRequestDto.LikedId = LikeMemberId;
                //likesPostRequestDto.LikedById = int.Parse(memberId);
                Like newlike = new Like();
                newlike.LikedId = LikeMemberId;
                newlike.LikedById = int.Parse(memberId);
                var result = await _services.Create(newlike);
                _logger.LogInformation("Created new Like");
                return Ok(result);
            }
            catch(LikeDuplicateException lde)
            {
                _logger.LogError("Like Already found Exception");
                return BadRequest(new ErrorModel(409,lde.Message));
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
        #endregion

        /// <summary>
        /// Get Like using LikeId
        /// </summary>
        /// <param name="LikeId"></param>
        /// <returns></returns>

        [HttpGet]
        [Authorize]
        [Route("GetByMemberId")]
        [ProducesResponseType(typeof(Like), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Like>> GetLkesWithMemberId()
        {
            try
            {
                var memberId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var result = await _likeServices.GetLikesWithMemberId(int.Parse(memberId));
                _logger.LogInformation("Getting Like using MemberId");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Member Found");
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
