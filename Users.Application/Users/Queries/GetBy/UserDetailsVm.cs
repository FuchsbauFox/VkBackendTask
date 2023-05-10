using System;
using AutoMapper;
using Users.Application.Common.Mapping;
using Users.Domain;

namespace Users.Application.Users.Queries.GetBy
{
    public class UserDetailsVm : IMapWith<User>
    {
        public Guid Id { get; set; }

        public UserGroup UserGroup { get; set; }

        public UserState UserState { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(userVm => userVm.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.UserGroup,
                    opt => opt.MapFrom(user => user.UserGroup))
                .ForMember(userVm => userVm.UserState,
                    opt => opt.MapFrom(user => user.UserState))
                .ForMember(userVm => userVm.Login,
                    opt => opt.MapFrom(user => user.Login))
                .ForMember(userVm => userVm.CreatedDate,
                    opt => opt.MapFrom(user => user.CreatedDate));
        }
    }
}