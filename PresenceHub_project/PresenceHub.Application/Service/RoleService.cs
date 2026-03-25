
using PresenceHub.Application.InterfaceService;
using PresenceHub.Domain.Entity;
using PresenceHub.Domain.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Application.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repo;

        public RoleService(IRoleRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            return await _repo.CreateAsync(role);
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            return await _repo.UpdateAsync(role);
        }

        public async Task<Role> DeleteRoleAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
