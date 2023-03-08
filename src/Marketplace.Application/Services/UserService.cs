using Marketplace.Application.Exceptions;
using Marketplace.Application.Helpers;
using Marketplace.Application.Models.User;
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
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        private readonly IConfiguration _configuration;


        public UserService(
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            IPasswordHasher<IdentityUser> passwordHasher,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
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
                    Username = loginUserModel.Username,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }
            return new LoginResponseModel
            {
                Username = "Error",
                Token = "Error"
            };
        }

        public async Task<RegisterUserModel> RegisterAsync([FromBody] RegisterUserModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
            {
                throw new BadRequestException("User already exists!");
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
                throw new BadRequestException("User creation failed! Please check user details and try again.");
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

            await _userManager.AddToRoleAsync(user, UserRoles.Customer);

            return new RegisterUserModel
            {
                Email = model.Email,
                Password = model.Password,
                UserName = model.UserName
            };
        }

        public async Task<RegisterUserModel> RegisterSellerAsync([FromBody] RegisterUserModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
            {
                throw new BadRequestException("User already exists!");
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
                throw new BadRequestException("User creation failed! Please check user details and try again.");
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

            await _userManager.AddToRoleAsync(user, UserRoles.Seller);

            return new RegisterUserModel
            {
                Email = model.Email,
                Password = model.Password,
                UserName = model.UserName
            };
        }

        public async Task<UpdateUserModel> UpdateAsync(Guid id, UpdateUserModel updateUserModel)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                if (!string.IsNullOrEmpty(updateUserModel.Email))
                {
                    user.Email = updateUserModel.Email;
                }
                else
                {
                    throw new BadRequestException("Field cannot be empty");
                }

                if (!string.IsNullOrEmpty(updateUserModel.Password))
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, updateUserModel.Password);
                }
                else
                {
                    throw new BadRequestException("Field cannot be empty");
                }

                if (!string.IsNullOrEmpty(updateUserModel.Email) && !string.IsNullOrEmpty(updateUserModel.Password))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (!result.Succeeded)
                    {
                        throw new BadRequestException("User updating failed! Please try again.");
                    }
                }
            }
            else
            {
                throw new NotFoundException("User not found");
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
                    return new Response { Status = "Error", Message = "User deleting failed! Please try again." };
                }
            }
            else
            {
                return new Response { Status = "Error", Message = "User not found" };
            }
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

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
