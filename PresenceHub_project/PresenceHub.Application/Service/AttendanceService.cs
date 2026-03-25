using AutoMapper;
using log4net;
using Microsoft.EntityFrameworkCore;
using PresenceHub.Application.DTO;
using PresenceHub.Application.InterfaceService;
using PresenceHub.Domain.Entity;
using PresenceHub.Domain.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Application.Service
{
    public class AttendanceService : IAttendanceService
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AttendanceService));
        private readonly IAttendanceRepository _repo;
        private readonly IMapper _mapper;
       
       


        public AttendanceService(IAttendanceRepository repo, IMapper mapper )
        {
            _repo = repo;
            _mapper = mapper;
            
           }
       
        public async Task<List<Attendance>> GetAllAsync()
        {
            _logger.Info("Fetching all attendance records");

            var data = await _repo.GetAllAsync();

            _logger.Info($"Fetched {data.Count} records");

            return _mapper.Map<List<Attendance>>(data);
        }

       public async Task<Attendance?> GetByIdAsync(int id)
        {
            _logger.Info($"Fetching attendance with ID: {id}");

            var data = await _repo.GetByIdAsync(id);

            if (data == null)
            {
                _logger.Warn($"Attendance not found: {id}");
                return null;
            }

            return _mapper.Map<Attendance>(data);
        }

       public async Task<Attendance> CreateAsync(AttendanceCreateDto dto)
        {
            var entity = _mapper.Map<Attendance>(dto);
            var result = await _repo.CreateAsync(entity);
            return _mapper.Map<Attendance>(result);
        }

        public async Task<Attendance> UpdateAsync(AttendanceUpdateDto dto)
        {
            var entity = _mapper.Map<Attendance>(dto);
            var result = await _repo.UpdateAsync(entity);
            return _mapper.Map<Attendance>(result);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}


