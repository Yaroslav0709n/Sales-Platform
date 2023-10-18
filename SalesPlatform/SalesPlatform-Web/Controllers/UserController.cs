using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesPlatform_Application.Dtos.User;
using SalesPlatform_Application.IServices;

namespace SalesPlatform_Web.Controllers
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

        [HttpGet("userId"), Authorize]
        public async Task<ActionResult> GetUserById(string userId)
        {
            var user = await _userService.GetUser(userId);
            
            return Ok(user);
        }

        [HttpGet, Authorize]
        public async Task<ActionResult> GetCurrentUser()
        {
            var user = await _userService.GetCurrentUser();

            return Ok(user);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            var user = await _userService.UpdateUser(updateUserDto);

            return Ok(user);
        }
    }
}
