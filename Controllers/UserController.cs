using ISC_BT2.Models;
using ISC_BT2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISC_BT2.Controllers
{
    [Route("api/users")]
    [ApiController]
    // [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
          [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (await _userService.CreateUser(user))
                return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.UserId) return BadRequest();

            if (await _userService.UpdateUser(user))
                return NoContent();

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (await _userService.DeleteUser(id))
                return NoContent();

            return NotFound();
        }
    }
}


// using ISC_BT2.Data;
// using ISC_BT2.Models;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace ISC_BT2.Controller{


// [Route("api/[controller]")]
// [ApiController]
// public class UserController : ControllerBase
// {
//     private readonly ApplicationDbContext _context;

//     public UserController(ApplicationDbContext context)
//     {
//         _context = context;
//     }

//     [HttpGet]
//     public async Task<IActionResult> GetUsers()
//     {
//         var users = await _context.Users.Include(u => u.Role).ToListAsync();
//         return Ok(users);
//     }

//     [HttpPost]
//     public async Task<IActionResult> CreateUser([FromBody] User user)
//     {
//         _context.Users.Add(user);
//         await _context.SaveChangesAsync();
//         return CreatedAtAction(nameof(GetUsers), new { id = user.UserId }, user);
//     }
// }

// }