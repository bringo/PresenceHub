using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PresenceHub.Domain.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; } // store hashed in real apps
        public string Email { get; set; }

        public int RoleId { get; set; }
        public DateTime CreationTime { get; set; }

        public Role Role { get; set; }

        public UserDetails UserDetails { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
    }
}
