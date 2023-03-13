using Marketplace.Application.ErrorMessages;
using Marketplace.Application.Exceptions;
using Marketplace.Application.Helpers;
using Marketplace.Application.Models.User;
using Marketplace.Application.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Marketplace.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;

        public UserService(
            UserManager<IdentityUser> userManager, 
            IPasswordHasher<IdentityUser> passwordHasher)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        public IQueryable<IdentityUser> GetAllAsync()
        {
            return _userManager.Users;
        }
        public async Task<UpdateUserModel> UpdateAsync(Guid id, UpdateUserModel updateUserModel)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                user.Email = updateUserModel.Email;
                user.PasswordHash = _passwordHasher.HashPassword(user, updateUserModel.Password);

                if (!string.IsNullOrEmpty(updateUserModel.Email) && !string.IsNullOrEmpty(updateUserModel.Password))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (!result.Succeeded)
                    {
                        throw new BadRequestException(UserErrorMessages.UserUpdatingFailed);
                    }
                }
            }
            else
            {
                throw new NotFoundException(UserErrorMessages.UserNotFound);
            }
            return new UpdateUserModel
            {
                Email = updateUserModel.Email,
                Password = updateUserModel.Password,
            };
        }

        public async Task<Response> DeleteAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return new Response { Status = "Success", Message = "User delete successfully!" };
                }
                else
                {
                    return new Response { Status = "Error", Message = UserErrorMessages.UserDeletingFailed };
                }
            }
            else
            {
                return new Response { Status = "Error", Message = UserErrorMessages.UserNotFound };
            }
        }
    }
}
