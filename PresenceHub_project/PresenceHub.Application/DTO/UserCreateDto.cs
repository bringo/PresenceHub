using PresenceHub.Application.DTO;
namespace PresenceHub.Application.DTO
{
    public class UserCreateDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public UserDetailsDto UserDetails { get; set; }
    }
}