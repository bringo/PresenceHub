using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Application.DTO
{
    public class AttendanceCreateDto
    {
        public int UserId { get; set; }
        public int RecordedBy { get; set; }
        public DateOnly Date { get; set; }
        public string Status { get; set; }
        public string Course { get; set; }
    }
}
