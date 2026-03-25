using PresenceHub.Application.DTO;
using PresenceHub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Application.InterfaceService
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetAll();
        Task<UserReadDto?> GetById(int id);
        Task<UserReadDto> Create(UserCreateDto dto);
        Task<UserReadDto> Update(int id, UserCreateDto dto);
        Task<bool> Delete(int id);
    }
}
