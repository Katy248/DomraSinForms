using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DomraSinForms.Persistence.Extensions;
public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services) =>
        services;
}
