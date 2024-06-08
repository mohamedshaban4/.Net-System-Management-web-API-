using AutoMapper;
using SystemManagement.Application.Dtos;
using SystemManagement.Application.DTOs;
using SystemManagement.Core.Entities;

namespace SystemManagement.Application.Mappings.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
                CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ReverseMap();

            CreateMap<CreateUserDto, User>()
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
               .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
               .ReverseMap();

            CreateMap<UpdateUserDto, User>().ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<CreateRoleDto, Role>().ReverseMap();

            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<CreatePermissionDto, Permission>().ReverseMap();

            CreateMap<Log, LogDto>().ReverseMap();
            CreateMap<CreateLogDto, Log>().ReverseMap();

            CreateMap<Setting, SettingDto>().ReverseMap();
            CreateMap<Setting, CreateSettingDto>().ReverseMap();
            CreateMap<Setting, UpdateSettingDto>().ReverseMap();





        }
    }
}
