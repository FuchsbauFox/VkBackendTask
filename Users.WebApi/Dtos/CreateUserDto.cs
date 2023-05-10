using AutoMapper;
using Users.Application.Common.Mapping;
using Users.Application.Users.Commands.Create;

namespace Users.WebApi.Dtos
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        public string Login { get; set; }
        
        public string Password { get; set; }
        
        public string UserGroupCode { get; set; }
        
        public string UserGroupDescription { get; set; }
        
        public string UserStateDescription { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(userCommand => userCommand.Login,
                    opt => opt.MapFrom(userDto => userDto.Login))
                .ForMember(userCommand => userCommand.Password,
                    opt => opt.MapFrom(userDto => userDto.Password))
                .ForMember(userCommand => userCommand.UserGroupCode,
                    opt => opt.MapFrom(userDto => userDto.UserGroupCode))
                .ForMember(userCommand => userCommand.UserGroupDescription,
                    opt => opt.MapFrom(userDto => userDto.UserGroupDescription))
                .ForMember(userCommand => userCommand.UserStateDescription,
                    opt => opt.MapFrom(userDto => userDto.UserStateDescription));
        }
    }
}