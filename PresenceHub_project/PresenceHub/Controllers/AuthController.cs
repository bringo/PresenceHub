using Microsoft.AspNetCore.Mvc;
using PresenceHub.Application.DTO;
using PresenceHub.Application.InterfaceService;

namespace PresenceHub.Controllers
{
    
    
        [ApiController]
        [Route("api/[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly IAuthService _authService;

            public AuthController(IAuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login(LoginDto dto)
            {
            var token = await _authService.LoginAsync(dto);

            if (token == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { Token = token });
        }
        }
    }

