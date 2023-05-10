using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Application.Interfaces;
using Users.Application.Users.Queries.GetBy;

namespace Users.Application.Users.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, UserListVm>
    {
        private readonly IUserDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IUserDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserListVm> Handle(GetAllQuery request,
            CancellationToken cancellationToken)
        {
            var users = await _dbContext.Users
                .ProjectTo<UserDetailsVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UserListVm { Users = users };
        }
    }
}