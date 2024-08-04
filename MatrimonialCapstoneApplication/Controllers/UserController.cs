using EcommerceApplication.Models.DTOs.RequestDTOs;
using EcommerceApplication.Models.DTOs.ReturnDTOs;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialCapstoneApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices _service;
        private ILogger<UserController> _logger;

        public UserController(IUserServices service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> Register(RegisterRequestDTO registerRequestDTO)
        {
            try
            {
                var result = await _service.Register(registerRequestDTO);
                _logger.LogInformation("Registered new user");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LoginReturnDTO>> Login(LoginRequestDTO loginRequestDTO)
        {
            try
            {
                var result = await _service.Login(loginRequestDTO);
                _logger.LogInformation("User Logged In "+ loginRequestDTO.Email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }
    }
}
