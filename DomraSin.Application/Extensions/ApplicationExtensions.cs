using Carter;
using DomraSin.Application.Services.Authentication;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DomraSin.Application.Extensions;
public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services) =>
        services.AddMediatR(builder =>
        {

        })
        .AddCarter()
        .AddValidatorsFromAssembly(typeof(ApplicationExtensions).Assembly)
        .AddTransient<PasswordService>()
        .AddTransient<JwtAuthenticationService>();
}
