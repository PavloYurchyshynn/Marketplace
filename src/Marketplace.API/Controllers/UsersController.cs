using Marketplace.Application.Models.User;
using Marketplace.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("users")]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_userService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("users")]
        public async Task<IActionResult> Update(Guid id, UpdateUserModel updateUserModel)
        {
            try
            {
                var updateUser = await _userService.UpdateAsync(id, updateUserModel);
                return Ok(updateUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("users")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var status = await _userService.DeleteAsync(id);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
