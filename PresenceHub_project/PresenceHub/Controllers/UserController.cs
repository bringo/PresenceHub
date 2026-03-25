using Microsoft.AspNetCore.Mvc;
using PresenceHub.Application.DTO;
using PresenceHub.Application.InterfaceService;
using PresenceHub.Domain.Entity;

namespace PresenceHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
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
                var user = await _service.GetById(id);
                if (user == null) return NotFound();

                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto dto)
        {
            try
            {
                var user = await _service.Create(dto);
                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserCreateDto dto)
        {
            try
            {
                return Ok(await _service.Update(id, dto));
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
                var result = await _service.Delete(id);
                if (!result) return NotFound();

                return Ok("Deleted");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}