using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Application.Common.Exceptions;
using Users.Application.Interfaces;
using Users.Application.Users.Queries.GetBy;
using Users.Domain;
using Timer = System.Timers.Timer;

namespace Users.Application.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private static readonly Timer Timer = new(5000);

        private readonly IUserDbContext _dbContext;
        private readonly HashSet<string> _logins = new();

        public CreateUserCommandHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (await CheckUser(command.Login, cancellationToken))
                throw new AlreadyExistException(command.Login);

            var userGroup = new UserGroup
            {
                Id = Guid.NewGuid(),
                Code = command.UserGroupCode,
                Description = command.UserGroupDescription
            };

            var userState = new UserState
            {
                Id = Guid.NewGuid(),
                Description = command.UserStateDescription
            };

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserGroupId = userGroup.Id,
                UserStateId = userState.Id,
                Login = command.Login,
                Password = command.Password,
            };

            Timer.Elapsed += async (_, _) =>
            {
                await _dbContext.UserGroups.AddAsync(userGroup, cancellationToken);
                await _dbContext.UserStates.AddAsync(userState, cancellationToken);
                await _dbContext.Users.AddAsync(user, cancellationToken);

                _logins.Remove(command.Login);
                Timer.Close();
            };

            Timer.AutoReset = false;
            Timer.Enabled = true;

            return user.Id;
        }

        private async Task<bool> CheckUser(string login, CancellationToken cancellationToken)
        {
            if (_logins.Contains(login)) return false;

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login, cancellationToken);
            if (user != null) return false;

            _logins.Add(login);
            return true;
        }
    }
}