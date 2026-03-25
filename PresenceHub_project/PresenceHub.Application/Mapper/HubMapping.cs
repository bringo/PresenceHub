using AutoMapper;
using PresenceHub.Application.DTO;
using PresenceHub.Domain.Entity;
namespace PresenceHub.Application.Mapper
{
    public class HubMapping : Profile
    {
        public HubMapping()
        {
            CreateMap<User, UserReadDto>()
                .ForMember(dest => dest.RoleName,
                    opt => opt.MapFrom(src => src.Role.RoleName));

            CreateMap<UserDetails, UserDetailsDto>().ReverseMap();

            CreateMap<UserCreateDto, User>();
            CreateMap<Attendance, AttendanceReadDto>()
                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.RecordedUserName,
                    opt => opt.MapFrom(src => src.RecordedUser.Username));
             CreateMap<AttendanceCreateDto, Attendance>();
            CreateMap<AttendanceUpdateDto, Attendance>();

        }
    }
}
