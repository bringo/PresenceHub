using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresenceHub.Domain.Entity
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        [ForeignKey("(UserId)")]
        public int UserId { get; set; }
        public DateOnly Date { get; set; }
        public string Status { get; set; }
        public string Course { get; set; }
        [ForeignKey("UserId")]
        public int RecordedBy { get; set; }
        public User User { get; set; }
    }
}