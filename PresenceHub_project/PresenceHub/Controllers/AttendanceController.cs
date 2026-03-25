using Microsoft.AspNetCore.Mvc;
using PresenceHub.Application.DTO;
using PresenceHub.Application.InterfaceService;
using PresenceHub.Domain.Entity;

namespace PresenceHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _service;
       

        public AttendanceController(IAttendanceService service)
        {
            _service = service;
           
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAllAsync());
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
                var result = await _service.GetByIdAsync(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(AttendanceCreateDto dto)
        {
            try
            {
                return Ok(await _service.CreateAsync(dto));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(AttendanceUpdateDto dto)
        {
            try
            {
                return Ok(await _service.UpdateAsync(dto));
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
                var success = await _service.DeleteAsync(id);
                if (!success) return NotFound();
                return Ok("Deleted");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
