using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Helpers;
using BusinessLogicLayer.IServices;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UpUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<UpUser> userManager, 
                            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ResponceModel> LoginAsync(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
                return new ResponceModel
                {
                    Message = "there is no User with this email !",
                    IsSuccess = false,
                };

            var result = await _userManager.CheckPasswordAsync(user, loginModel.Password);
            if (!result)
            {
                return new ResponceModel
                {
                    Message = "Invalid Password !",
                    IsSuccess = false,
                };
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, loginModel.Email),
                new Claim(ClaimTypes.Name, loginModel.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:ValidIssuer"],
                audience: _configuration["Jwt:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new ResponceModel()
            {
                Message = generatedToken,   
                IsSuccess = true,
                ExpiredTime = token.ValidTo
            };
        }

        public async Task<ResponceModel> RegisterAsync(RegisterModel registerModel)
        {
            if(registerModel == null) 
                throw new ArgumentNullException(nameof(registerModel));

            var userExista = await _userManager.FindByEmailAsync(registerModel.Email);

            if (userExista != null)
                return new ResponceModel { Message = "User already exists", IsSuccess = false };

            var use = new UpUser 
            { 
                Email = registerModel.Email, 
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.UserName 
            };

            var result = await _userManager.CreateAsync(use, registerModel.Password);
            return new ResponceModel
            {
                Message = result.Succeeded ? "User created successfully" : "User cannot created !",
                IsSuccess = result.Succeeded,
                ExpiredTime = DateTime.Now,
                Errors = result.Errors.Select(c => c.Description).ToList()
            };

            //if (result.Succeeded)
            //{
            //    return new ResponceModel
            //    {
            //        Message = "User created successfully !",
            //        IsSuccess = true,
            //        ExpiredTime = DateTime.Now,
            //    };
            //}
            //return new ResponceModel()
            //{
            //    Message = "User cannot created ",
            //    IsSuccess = false,
            //    ExpiredTime = DateTime.Now,
            //};
        }


    }
}
