using MicroserviceAralik.Services.Cargo.BusinessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.BusinessLayer.Concrete;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Concrete;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.EntityFramework;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MicroserviceAralik.Services.Cargo.BusinessLayer.Extensions;
public static class ServiceRegisterations
{
    public static void RegisterBusinessLayer(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();

        services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
        services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));

        services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
        services.AddScoped<ICargoDetailService, CargoDetailManager>();

        services.AddScoped<ICompanyDal, EfCompanyDal>();
        services.AddScoped<ICompanyService, CompanyManager>();

        services.AddScoped<ICustomerDal, EfCustomerDal>();
        services.AddScoped<ICustomerService, CustomerManager>();

        services.AddScoped<IOperationDal, EfOperationDal>();
        services.AddScoped<IOperationService, OperationManager>();

    }
}
