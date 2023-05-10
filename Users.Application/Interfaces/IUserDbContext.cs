using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users.Domain;

namespace Users.Application.Interfaces
{
    public interface IUserDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<UserState> UserStates { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}