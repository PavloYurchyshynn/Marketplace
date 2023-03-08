using Marketplace.Application.Models.User;
using Marketplace.Application.Services.Contracts;
using Marketplace.Application;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticateController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel model)
        {
            try
            {
                var user = await _userService.LoginAsync(model);
                if (user.Token == "Error")
                {
                    return Unauthorized();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserModel model)
        {
            try
            {
                var user = await _userService.RegisterAsync(model, UserRoles.Customer);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("register-seller")]
        public async Task<IActionResult> RegisterSeller([FromBody] RegisterUserModel model)
        {
            try
            {
                var user = await _userService.RegisterAsync(model, UserRoles.Seller);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
