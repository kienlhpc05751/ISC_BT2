using ISC_BT2.Models;
using ISC_BT2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISC_BT2.Controllers
{
    [Route("api/access")]
    [ApiController]
    public class AllowAccessController : ControllerBase
    {
        private readonly AllowAccessService _accessService;

        public AllowAccessController(AllowAccessService accessService)
        {
            _accessService = accessService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccesses()
        {
            return Ok(await _accessService.GetAllAccesses());
        }

        [HttpPost]
        public async Task<IActionResult> GrantAccess([FromBody] AllowAccess access)
        {
            if (await _accessService.GrantAccess(access))
                return Ok(new { message = "Access granted successfully" });

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RevokeAccess(int id)
        {
            if (await _accessService.RevokeAccess(id))
                return NoContent();

            return NotFound();
        }
    }
}
