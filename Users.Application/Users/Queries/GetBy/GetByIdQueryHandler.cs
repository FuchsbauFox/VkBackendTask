using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Application.Common.Exceptions;
using Users.Application.Interfaces;
using Users.Domain;

namespace Users.Application.Users.Queries.GetBy
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, UserDetailsVm>
    {
        private readonly IUserDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IUserDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserDetailsVm> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (user == null)
                throw new NotFoundException(nameof(User), request.Id);

            return _mapper.Map<UserDetailsVm>(user);
        }
    }
}