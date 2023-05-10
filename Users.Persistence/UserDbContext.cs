using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Users.Application.Interfaces;
using Users.Domain;

namespace Users.Persistence
{
    public class UserDbContext : DbContext, IUserDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<UserState> UserStates { get; set; }

        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
    
    public class Factory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder()
                .UseNpgsql("FakeConnectionStringOnlyForMigrations")
                .Options;

            return new UserDbContext(options);
        }
    }
}