using PresenceHub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Domain.InterfaceRepo
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User?> Delete(int id);
    }
}
