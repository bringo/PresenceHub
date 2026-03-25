using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Application.DTO
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string RoleName { get; set; }

        public UserDetailsDto UserDetails { get; set; }
    }
}
