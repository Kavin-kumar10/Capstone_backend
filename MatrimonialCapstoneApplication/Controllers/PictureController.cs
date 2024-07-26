using MatrimonialCapstoneApplication.Exceptions.ImageUploadExceptions;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Models;
using MatrimonialCapstoneApplication.Models.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MatrimonialCapstoneApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private IServices<int, Picture> _services;
        private IPictureServices _pictureServices;
        ILogger<PictureController> _logger;

        public PictureController(IServices<int, Picture> services, ILogger<PictureController> logger, IPictureServices pictureServices)
        {
            _services = services;
            _logger = logger;
            _pictureServices = pictureServices;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Picture>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Picture>>> GetAllPictures()
        {
            try
            {
                var result = await _services.GetAll();
                _logger.LogInformation("Retriving all the pictures");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(404, ex.Message));
            }
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(IEnumerable<Picture>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Picture>>> GetPictureById(int PictureId)
        {
            try
            {
                var result = await _services.GetById(PictureId);
                _logger.LogInformation("Retriving the required picture");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(404, ex.Message));
            }
        }

        [HttpPost]
        [Route("{PersonalDetailsId}")]
        [ProducesResponseType(typeof(IEnumerable<Picture>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetPicture(int PersonalDetailsId,[FromForm]ImageRequestDto imagerequestDto)
        {
            try
            {
                var result = await _pictureServices.UploadImage(imagerequestDto);
                Console.WriteLine(result.FirstOrDefault());
                foreach (var picture in result)
                {
                    Picture newPic = new Picture { PersonalDetailsId = PersonalDetailsId, PictureUrl = picture };
                    var final_result = await _services.Create(newPic);
                }
                _logger.LogInformation("Uploading Pictures to Azure");
                return Ok();
            }
            catch(UnableToUploadException utue)
            {
                return BadRequest(new ErrorModel(500,utue.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(404, ex.Message));
            }
        }
    }
}
