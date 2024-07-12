using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DomraSinForms.Persistence;
public static class Extensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        return services
            .AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString,
                    options => options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name));
            })
            ;
    }
}
