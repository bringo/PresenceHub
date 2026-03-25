using PresenceHub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Application.InterfaceService
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByIdAsync(int id);
        Task<Role> CreateRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task<Role> DeleteRoleAsync(int id);
    }
}
