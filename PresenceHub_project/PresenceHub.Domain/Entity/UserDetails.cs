using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace PresenceHub.Domain.Entity
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Fullname { get; set; }
        public DateOnly Dob { get; set; }
        public string Gender { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public int Year { get; set; }

        [JsonIgnore] // 🔥 prevents circular loop
        public User User { get; set; }
    }
}
