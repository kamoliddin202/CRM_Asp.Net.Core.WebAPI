using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BusinessLogicLayer.Helpers;
using BusinessLogicLayer.IServices;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CRM_Asp.Net.Core.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<UpUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService,
                            UserManager<UpUser> userManager,
                            RoleManager<IdentityRole> roleManager,
                            IConfiguration configuration)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Some properties is not valid ");


                var result = await _userService.RegisterAsync(registerModel);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Unexpected error occured", Detail = ex.Message });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginAsync(loginModel);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
                
            }
            return BadRequest("Some properties are not valid !");
        }

        //    [HttpPost("login")]
        //    public async Task<IActionResult> Login(LoginModel loginModel)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = await _userManager.FindByNameAsync(loginModel.Email);

        //            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
        //            {
        //                var userRoles = await _userManager.GetRolesAsync(user);

        //                var authClaims = new List<Claim>
        //                {
        //                    new Claim(ClaimTypes.Name, user.UserName),
        //                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                };

        //                foreach (var role in userRoles)
        //                {
        //                    authClaims.Add(new Claim(ClaimTypes.Role, role));
        //                }

        //                var siningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

        //                var token = new JwtSecurityToken(
        //                    issuer: _configuration["JWT:ValidIssuer"],
        //                    audience: _configuration["JWT:ValidAudience"],
        //                    expires: DateTime.Now.AddDays(1),
        //                    claims: authClaims,
        //                    signingCredentials: new SigningCredentials(siningKey, SecurityAlgorithms.HmacSha256)
        //                    );

        //                return Ok(new ResponceModel
        //                {
        //                    Message = new JwtSecurityTokenHandler().WriteToken(token),
        //                    ExpiredTime = token.ValidTo
        //                });
        //            }
        //            return Unauthorized();
        //        }
        //        return BadRequest();
        //    }
    }
}

