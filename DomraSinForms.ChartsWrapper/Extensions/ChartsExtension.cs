using DomraSinForms.ChartsWrapper.Wrappers;
using Microsoft.Extensions.DependencyInjection;

namespace DomraSinForms.ChartsWrapper.Extensions;
public static class ChartsExtension
{
    public static IServiceCollection AddWrappers(this IServiceCollection services)
    {
        return services
            .AddScoped<ScriptWrapper>()
            .AddScoped<Wrapper>();
    }
}
