using PresenceHub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Application.InterfaceService
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
