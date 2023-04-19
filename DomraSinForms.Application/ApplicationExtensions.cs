using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomraSinForms.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace DomraSinForms.Application;
public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddMediatR(config =>
            {
                config.Lifetime = ServiceLifetime.Scoped;
                config.RegisterServicesFromAssembly(typeof(ApplicationExtensions).Assembly);
            })
            .AddAutoMapper(typeof(ApplicationExtensions).Assembly);

    }
}
