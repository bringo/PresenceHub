using PresenceHub.Application.DTO;
using PresenceHub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Application.InterfaceService
{
    public interface IAttendanceService
    {
        Task<List<Attendance>> GetAllAsync();
        Task<Attendance?> GetByIdAsync(int id);
        Task<Attendance> CreateAsync(AttendanceCreateDto dto);
        Task<Attendance> UpdateAsync(AttendanceUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        //Task<string?> LoginAsync(LoginDto dto);
    }
}
