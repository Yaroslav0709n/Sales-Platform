using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet, Authorize]
        public async Task<ActionResult> GetUserById(string userId)
        {
            var user = await _userService.GetUser(userId);
            
            return Ok(user);
        }

    }
}
