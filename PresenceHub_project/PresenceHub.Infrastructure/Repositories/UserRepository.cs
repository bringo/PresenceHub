using Microsoft.EntityFrameworkCore;
using PresenceHub.Application.InterfaceService;
using PresenceHub.Domain.Entity;
using PresenceHub.Domain.InterfaceRepo;
using PresenceHub.Infrastructure.DB_Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HubDBcontext _context;

        public UserRepository(HubDBcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.User
                .Include(u => u.Role)
                .Include(u => u.UserDetails)
                .ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.User
                .Include(u => u.Role)
                .Include(u => u.UserDetails)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> Create(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            var existing = await _context.User.FindAsync(user.Id);

            if (existing == null)
                throw new KeyNotFoundException();

            existing.Username = user.Username;
            existing.Email = user.Email;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<User?> Delete(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null) return null;

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
