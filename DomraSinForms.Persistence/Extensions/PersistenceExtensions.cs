using DomraSin.Persistance;
using DomraSinForms.Domain.Interfaces.Repositories;
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
                options.UseNpgsql(connectionString,
                    dbOptions =>
                    {
                        dbOptions.MigrationsAssembly(typeof(PersistenceExtensions).Assembly.FullName);
                    });
            });
}
