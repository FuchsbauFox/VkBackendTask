using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Interfaces;

namespace Users.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<UserDbContext>(options => { options.UseNpgsql(connectionString); });
            services.AddScoped<IUserDbContext>(provider => provider.GetService<UserDbContext>());
            return services;
        }
    }
}