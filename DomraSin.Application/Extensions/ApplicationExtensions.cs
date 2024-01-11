using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSin.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DomraSin.Application.Extensions;
public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services) =>
        services.AddMediatR(builder =>
        {

        })
        .AddTransient<PasswordService>();
}
