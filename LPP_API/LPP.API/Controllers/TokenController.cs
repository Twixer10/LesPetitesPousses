using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LPP.DTO;
using LPP.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace LPP.API.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        
        public TokenController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto loginUser)
        {
            var user = await _userService.GetUserByIdentifier(loginUser.Identifiant!, loginUser.Password!);

            if (user is not null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("FirstName", user.Firstname),
                    new Claim("LastName", user.Lastname),
                    new Claim("Email", user.Email),
                    new Claim("Role", user.IsAdmin ? "Admin" : "User"),
                    new Claim("Pseudo", user.Pseudo)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"], 
                    claims, // Here we are adding Claims to the token
                    expires: DateTime.UtcNow.AddDays(10),  //Here we are setting the expiration time of token
                    signingCredentials: signIn);
                var newDto = new UserDto(user) {Token = new JwtSecurityTokenHandler().WriteToken(token) };
            // return ok with custom json
            return Ok(newDto);
            }
            else
            {
                return BadRequest(new { message = "L'identifiant ou le mot de passe est incorrect" });
            }
        }
    }
