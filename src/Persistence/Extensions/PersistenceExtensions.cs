using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DomraSinForms.Persistence.Extensions;
public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, string connectionString) =>
        services
            .AddScoped<IUsersRepository, UserRepository>()
            .AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString: connectionString,
                    dbOptions =>
                    {
                        dbOptions.MigrationsAssembly(typeof(PersistenceExtensions).Assembly.FullName);
                    });
            });
}
