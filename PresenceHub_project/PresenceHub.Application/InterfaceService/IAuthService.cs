using PresenceHub.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Application.InterfaceService
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginDto dto);

    }
}
