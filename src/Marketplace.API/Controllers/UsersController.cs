using Marketplace.Application.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Marketplace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;

        public UsersController(UserManager<IdentityUser> userManager, IPasswordHasher<IdentityUser> passwordHasher)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_userManager.Users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, string email, string password)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                if (!string.IsNullOrEmpty(email))
                {
                    user.Email = email;
                }
                else
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, new Response { Status = "Error", Message = "Field cannot be empty" });
                }

                if (!string.IsNullOrEmpty(password))
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, password);
                }
                else
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, new Response { Status = "Error", Message = "Field cannot be empty" });
                }

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return Ok(new Response { Status = "Success", Message = "User update successfully!" });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User updating failed! Please try again." });
                    }
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "User not found" });
            }
            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return Ok(new Response { Status = "Success", Message = "User delete successfully!" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User deleting failed! Please try again." });
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "User not found" });
            }
        }
    }
}
