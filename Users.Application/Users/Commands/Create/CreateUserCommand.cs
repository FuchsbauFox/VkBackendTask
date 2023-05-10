using System;
using MediatR;
using Users.Domain.Enums;

namespace Users.Application.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Login { get; set; }
        
        public string Password { get; set; }
        
        public Role UserGroupCode { get; set; }
        
        public string UserGroupDescription { get; set; }
        
        public string UserStateDescription { get; set; }
    }
}