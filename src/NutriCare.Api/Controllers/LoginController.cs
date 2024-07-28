using Microsoft.AspNetCore.Mvc;
using NutriCare.Api.Interfaces;
using NutriCare.Api.Models;
using NutriCare.Api.Services;

namespace NutriCare.Api.Controllers
{
[ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public LoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginRequestModel model)
        {
            // Validate user credentials (e.g., check against database)
            // If valid, generate a token
            var userId = "123"; // Replace with actual user ID
            var userEmail = "user@example.com"; // Replace with actual user email

            var token = _tokenService.GenerateToken(userId, userEmail);

            return Ok(new { token });
        }
    }
}