using AutoMapper;
using PresenceHub.Application.DTO;
using PresenceHub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Application.Mapper
{
    public class AttendanceProfile : Profile
    {
        public AttendanceProfile()
        {
            
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
