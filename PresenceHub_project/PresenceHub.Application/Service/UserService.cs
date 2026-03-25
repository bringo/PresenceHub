using AutoMapper;
using log4net;
using PresenceHub.Application.DTO;
using PresenceHub.Application.InterfaceService;
using PresenceHub.Domain.Entity;
using PresenceHub.Domain.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PresenceHub.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserReadDto>> GetAll()
        {
            var users = await _repo.GetAll();
            return _mapper.Map<IEnumerable<UserReadDto>>(users);
        }

        public async Task<UserReadDto?> GetById(int id)
        {
            var user = await _repo.GetById(id);
            return _mapper.Map<UserReadDto>(user);
        }

        public async Task<UserReadDto> Create(UserCreateDto dto)
        {
            var user = _mapper.Map<User>(dto);
            //user.CreationTime = DateTime.UtcNow;

            var created = await _repo.Create(user);
            return _mapper.Map<UserReadDto>(created);
        }

        public async Task<UserReadDto> Update(int id, UserCreateDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.Id = id;

            var updated = await _repo.Update(user);
            return _mapper.Map<UserReadDto>(updated);
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _repo.Delete(id);
            return result != null;
        }
    }
}
