using MatrimonialCapstoneApplication.Exceptions;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
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
    public class MatchesController : ControllerBase
    {
        private IServices<int, Match> _services;
        private IMatchesServices _matchServices;
        ILogger<MatchesController> _logger;
        public MatchesController(IServices<int, Match> services, ILogger<MatchesController> logger, IMatchesServices matchServices)
        {
            _services = services;
            _logger = logger;
            _matchServices = matchServices;
        }

        /// <summary>
        /// Get Matches with member id
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<Match>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatcheswithMemId()
        {
            try
            {
                var memberId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var result = await _matchServices.GetMatchesWithMemberId(int.Parse(memberId));
                _logger.LogInformation("Get Match Details with Member Id");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Matches Found");
                return BadRequest(new ErrorModel(404, nfe.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unknown exceptions found");
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }


        /// <summary>
        /// Create new Match request using matchrequestDTO
        /// </summary>
        /// <param name="matchRequestDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Match), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Match>> postMatch(MatchRequestDto matchRequestDto)
        {
            try{
                var memberId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var newMatch = new Match();
                newMatch.MatchDate = DateTime.Now;
                newMatch.Status = "Pending";
                newMatch.Message = matchRequestDto.Message;
                newMatch.FromProfileId = int.Parse(memberId);
                newMatch.ToProfileId = matchRequestDto.ToProfileId;
                var result = await _services.Create(newMatch);
                return result;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(new ErrorModel(500, e.Message));
            }
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<Match>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Match>>> UpdateMatch(Match match)
        {
            try
            {
                var result = await _services.Update(match);
                _logger.LogInformation("Update match request");
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError("No such Matches Found");
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
