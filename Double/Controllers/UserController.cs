using Double.Core.IServices;
using Double.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Properties.Api.Exceptions;

namespace Double.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /*
            <summary>
            This endpoint will try to create a user
            </summary>
        */
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            try
            {
                var userResult = _userService.Create(user);
                _logger.LogInformation("Request successful!");

                return Ok(userResult == true ? "The user was created successful!" : "");
            }
            catch (Exception e)
            {
                _logger.LogError("Something went wrong! "+ e.Message);
                throw new InternalServerErrorException("Something went wrong! "+ e.Message);
            }
        }

        /*
            <summary>
            This endpoint will try to validate if a user exist
            </summary>
        */
        [HttpGet("{username}/{password}")]
        public IActionResult IsUser(string username, string password)
        {
            try
            {
                var isUser = _userService.IsUser(username, password);
                _logger.LogInformation("Request successful!");

                return Ok(isUser);
            }
            catch (Exception e)
            {
                _logger.LogError("Something went wrong! "+ e.Message);
                throw new InternalServerErrorException("Something went wrong! "+ e.Message);
            }
        }
    }
}
