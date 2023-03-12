using Marketplace.Application.ErrorMessages;
using Marketplace.Application.Exceptions;
using Marketplace.Application.Models.Auth;
using Marketplace.Application.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Marketplace.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        
        public async Task<LoginResponseModel> LoginAsync([FromBody] LoginUserModel loginUserModel)
        {
            var user = await _userManager.FindByNameAsync(loginUserModel.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginUserModel.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim("User id", user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return new LoginResponseModel
                {
                    Id = user.Id,
                    Username = loginUserModel.Username,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }
            return new LoginResponseModel
            {
                Id = "Error",
                Username = "Error",
                Token = "Error"
            };
        }

        public async Task<RegisterUserModel> RegisterAsync([FromBody] RegisterUserModel model, string role)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
            {
                throw new BadRequestException(CustomerErrorMessages.UserAlreadyExists);
            }

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                throw new BadRequestException(CustomerErrorMessages.UserCreationFailed);
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Seller))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Seller));
            }
            if (!await _roleManager.RoleExistsAsync(UserRoles.Customer))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));
            }
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }

            await _userManager.AddToRoleAsync(user, role);

            return new RegisterUserModel
            {
                Email = model.Email,
                Password = model.Password,
                UserName = model.UserName
            };
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

            var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
