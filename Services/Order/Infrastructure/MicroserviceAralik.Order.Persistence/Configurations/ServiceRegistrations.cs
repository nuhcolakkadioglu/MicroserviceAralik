using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroserviceAralik.Order.Application.Interfaces;
using MicroserviceAralik.Order.Persistence.Context;
using MicroserviceAralik.Order.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MicroserviceAralik.Order.Persistence.Configurations;
public static class ServiceRegistrations
{
    public static void AddGenericServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
         services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
         services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

    }
}
 