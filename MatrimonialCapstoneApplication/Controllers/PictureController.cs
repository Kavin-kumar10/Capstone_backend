using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialCapstoneApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private IServices<int, Picture> _services;

        public PictureController(IServices<int, Picture> services)
        {
            _services = services;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Picture>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Picture>>> GetAllPictures()
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
    }
}
