using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PresenceHub.Application.DTO;
using PresenceHub.Application.InterfaceService;
using PresenceHub.Domain.Entity;
using PresenceHub.Domain.InterfaceRepo;
using PresenceHub.Infrastructure.DB_Context;


namespace PresenceHub.Infrastructure.Repositories
{
  

    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly HubDBcontext _context;
        

        public AttendanceRepository(HubDBcontext context)
        {
            _context = context;
            
        }

        public async Task<List<Attendance>> GetAllAsync()
        {
            return await _context.Attendances
                .Include(a => a.User)
                .Include(a => a.RecordedUser)
                .ToListAsync();
        }

        public async Task<Attendance?> GetByIdAsync(int id)
        {
            return await _context.Attendances
                .Include(a => a.User)
                .Include(a => a.RecordedUser)
                .FirstOrDefaultAsync(a => a.AttendanceId == id);
        }

        public async Task<Attendance> CreateAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance> UpdateAsync(Attendance attendance)
        {
            var existing = await _context.Attendances.FindAsync(attendance.AttendanceId);

            if (existing == null)
                throw new Exception("Attendance not found");

            existing.UserId = attendance.UserId;
            existing.RecordedBy = attendance.RecordedBy;
            existing.Date = attendance.Date;
            existing.Status = attendance.Status;
            existing.Course = attendance.Course;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);

            if (attendance == null)
                return false;

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
            return true;
        }
      
    }
}
