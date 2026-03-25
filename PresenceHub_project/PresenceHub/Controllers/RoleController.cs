using Microsoft.AspNetCore.Mvc;
using PresenceHub.Application.InterfaceService;
using PresenceHub.Domain.Entity;

namespace PresenceHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

         public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAllRolesAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var role = await _service.GetRoleByIdAsync(id);
                if (role == null) return NotFound();
                return Ok(role);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Role role)
        {
            try
            {
                var result = await _service.CreateRoleAsync(role);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Role role)
        {
            try
            {
                var result = await _service.UpdateRoleAsync(role);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success = await _service.DeleteRoleAsync(id);
                if (success == null) return NotFound();
                return Ok("Deleted Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
