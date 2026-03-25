using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Application.DTO
{
    public class AttendanceUpdateDto
    {
        public int AttendanceId { get; set; }
        public int UserId { get; set; }
        public int RecordedBy { get; set; }
        public DateOnly Date { get; set; }
        public string Status { get; set; }
        public string Course { get; set; }
    }
}
