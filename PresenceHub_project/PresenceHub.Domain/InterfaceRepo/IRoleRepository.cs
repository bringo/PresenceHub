using PresenceHub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Domain.InterfaceRepo
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(int id);
        Task<Role> CreateAsync(Role role);
        Task<Role> UpdateAsync(Role role);
        Task<Role> DeleteAsync(int id);
    }
}
