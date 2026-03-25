using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Application.DTO
{
    public class UserDetailsDto
    {
        public string Fullname { get; set; }
        public DateOnly Dob { get; set; }
        public string Gender { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public int Year { get; set; }
    }
}
