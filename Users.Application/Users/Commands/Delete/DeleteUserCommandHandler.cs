using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Application.Common.Exceptions;
using Users.Application.Interfaces;
using Users.Domain;
using Users.Domain.Enums;

namespace Users.Application.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserDbContext _dbContext;

        public DeleteUserCommandHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (user == null)
                throw new NotFoundException(nameof(User), request.Id);

            var userState =
                await _dbContext.UserStates.FirstOrDefaultAsync(us => us.Id == user.UserStateId, cancellationToken);

            if (user == null)
                throw new NotFoundException(nameof(UserState), user.UserStateId);

            userState.Code = Status.Blocked;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}