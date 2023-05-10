using System;
using AutoMapper;
using Users.Application.Common.Mapping;
using Users.Domain;

namespace Users.Application.Users.Queries.GetBy
{
    public class UserStateDetailsVm: IMapWith<UserState>
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserGroup, UserGroupDetailsVm>()
                .ForMember(userVm => userVm.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.Code,
                    opt => opt.MapFrom(user => user.Code.ToString()))
                .ForMember(userVm => userVm.Description,
                    opt => opt.MapFrom(user => user.Description));
        }
    }
}