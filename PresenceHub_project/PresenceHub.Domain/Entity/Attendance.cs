using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresenceHub.Domain.Entity
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int RecordedBy { get; set; }

        [ForeignKey("RecordedBy")]
        public User RecordedUser { get; set; }

        public DateOnly Date { get; set; }
        public string Status { get; set; }
        public string Course { get; set; }
    }
}