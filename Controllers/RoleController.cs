using ISC_BT2.Models;
using ISC_BT2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISC_BT2.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await _roleService.GetAllRoles());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _roleService.GetRoleById(id);
            if (role == null) return NotFound();

            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] Role role)
        {
            if (await _roleService.CreateRole(role))
                return CreatedAtAction(nameof(GetRoleById), new { id = role.RoleId }, role);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] Role role)
        {
            if (id != role.RoleId) return BadRequest();

            if (await _roleService.UpdateRole(role))
                return NoContent();

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            if (await _roleService.DeleteRole(id))
                return NoContent();

            return NotFound();
        }
    }
}
