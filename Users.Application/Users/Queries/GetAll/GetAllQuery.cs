using System;
using MediatR;

namespace Users.Application.Users.Queries.GetAll
{
    public class GetAllQuery : IRequest<UserListVm>
    {
    }
}