using DomraSinForms.ChartsWrapper.Wrappers;
using Microsoft.Extensions.DependencyInjection;

namespace DomraSinForms.ChartsWrapper.Extensions;
public static class ChartsExtension
{
    public static IServiceCollection AddChartsWrapper(this IServiceCollection services)
    {
        return services.AddScoped<Wrapper>();
    }
}
