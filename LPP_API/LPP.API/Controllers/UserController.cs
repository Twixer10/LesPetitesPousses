using LPP.API.Exception;
using LPP.DTO;
using LPP.Entities;
using LPP.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [AllowAnonymous] // This data anotate is for allow access to this method without token
        [HttpPost]
        public async Task<IActionResult> Register(UserDto registerUser)

        {
            try
            {
                var user = await _userService.Register(registerUser);
                return Ok(new UserDto(user));
            }
            catch (System.Exception ex)
            {
                return ex switch
                {
                    EmailAlreadyUseException => Conflict(new { message = ex.Message }),
                    PseudoAlreadyUseException => Conflict(new { message = ex.Message }),
                    _ => BadRequest(new { message = ex.Message })
                };
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(new Guid(id));
                if (user is not null)
                    return Ok(new UserDto(user));
                else
                    return NotFound(new { message = "L'utilisateur n'a pas été trouvé" });
            }
            catch (System.Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}