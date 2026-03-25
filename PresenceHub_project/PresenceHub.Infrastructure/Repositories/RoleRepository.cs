
using PresenceHub.Domain.Entity;
using PresenceHub.Infrastructure.DB_Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PresenceHub.Domain.InterfaceRepo;

namespace PresenceHub.Infrastructure.Repositories
{
   
  
        public class RoleRepository : IRoleRepository
        {
            private readonly HubDBcontext _context;

            public RoleRepository(HubDBcontext context)
            {
                _context = context;
            }

            public async Task<List<Role>> GetAllAsync()
            {
                return await _context.Role.ToListAsync();
            }

            public async Task<Role?> GetByIdAsync(int id)
            {
                return await _context.Role.FindAsync(id);
            }

            public async Task<Role> CreateAsync(Role role)
            {
                await _context.Role.AddAsync(role);
                await _context.SaveChangesAsync();
                return role;
            }

            public async Task<Role> UpdateAsync(Role role)
            {
                var existing = await _context.Role.FindAsync(role.RoleId);

                if (existing == null)
                    throw new Exception("Role not found");

                existing.RoleName = role.RoleName;
                existing.Description = role.Description;

                await _context.SaveChangesAsync();
                return existing;
            }

            public async Task<Role> DeleteAsync(int id)
            {
                var role = await _context.Role.FindAsync(id);

                if (role == null)
                    return null;

                _context.Role.Remove(role);
                await _context.SaveChangesAsync();
               return role ;
            }

       
    }

    }

