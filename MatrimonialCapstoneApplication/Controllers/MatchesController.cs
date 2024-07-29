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
        [ProducesResponseType(typeof(IEnumerable<Match>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Member>>> GetMatcheswithMemId(int MemberId)
        {
            try
            {
                var result = await _matchServices.GetMatchesWithMemberId(MemberId);
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
    }
}
