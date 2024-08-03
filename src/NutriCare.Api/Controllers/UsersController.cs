using Microsoft.AspNetCore.Mvc;
using NutriCare.Api.Interfaces;

namespace NutriCare.Api.Controllers
{
 [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // Define your actions here
         [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log, return error response)
                return StatusCode(500, $"Error fetching users: {ex.Message}");
            }
        }
    } 
}