using Carter;
using DomraSinForms.Application.Services.Authentication;
using DomraSinForms.Domain.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DomraSinForms.Application.Extensions;
public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services) =>
        services.AddMediatR(builder =>
            {
                builder.RegisterServicesFromAssembly(typeof(ApplicationExtensions).Assembly);
            })
        .AddCarter()
        .AddValidatorsFromAssembly(typeof(ApplicationExtensions).Assembly)
        .AddTransient<IPassswordHasher, PasswordService>()
        .AddTransient<JwtAuthenticationService>();
}
