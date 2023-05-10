using System;
using MediatR;

namespace Users.Application.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}