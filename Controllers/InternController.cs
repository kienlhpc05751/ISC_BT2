using ISC_BT2.Services;
using ISC_BT2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ISC_BT2.Controllers
{
    [Route("api/interns")]
    [ApiController]
    public class InternController : ControllerBase
    {
        private readonly InternService _internService;
        private readonly ApplicationDbContext _context;

        public InternController(InternService internService, ApplicationDbContext context)
        {
            _internService = internService;
            _context = context;
        }

        // [Authorize]
        [HttpGet]
        [Authorize(Policy = "UserAccess")]
        public async Task<IActionResult> GetInterns()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _context.Users.FindAsync(int.Parse(userId));

            if (user == null)
                return Unauthorized();

            return Ok(await _internService.GetInternsForUser(user.RoleId));
        }
    }
}
