using Marketplace.Application.Helpers;
using Marketplace.Application.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Application.Services.Contracts
{
    public interface IUserService
    {
        Task<LoginResponseModel> LoginAsync([FromBody] LoginUserModel loginUserModel);
        Task<RegisterUserModel> RegisterAsync([FromBody] RegisterUserModel registerUserModel, string role);
        Task<UpdateUserModel> UpdateAsync(Guid id, UpdateUserModel updateUserModel);
        Task<Response> DeleteAsync(Guid id);
    }
}
