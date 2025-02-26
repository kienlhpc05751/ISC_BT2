using ISC_BT2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISC_BT2.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.AuthenticateUser(request.Username, request.Password);
            if (token == null) return Unauthorized(new { message = "Invalid email or password" });

            return Ok(new { token });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
