using System;
using MediatR;

namespace Users.Application.Users.Queries.GetBy
{
    public class GetByIdQuery : IRequest<UserDetailsVm>
    {
        public Guid Id { get; set; }
    }
}