using Marketplace.Application.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Application.Services.Contracts
{
    public interface IAuthService
    {
        Task<LoginResponseModel> LoginAsync([FromBody] LoginUserModel loginUserModel);
        Task<RegisterUserModel> RegisterAsync([FromBody] RegisterUserModel registerUserModel, string role);
    }
}
