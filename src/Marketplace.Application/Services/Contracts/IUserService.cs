using Marketplace.Application.Helpers;
using Marketplace.Application.Models.User;
using Microsoft.AspNetCore.Identity;

namespace Marketplace.Application.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<IdentityUser> GetAllAsync();
        Task<UpdateUserModel> UpdateAsync(Guid id, UpdateUserModel updateUserModel);
        Task<Response> DeleteAsync(Guid id);
    }
}
