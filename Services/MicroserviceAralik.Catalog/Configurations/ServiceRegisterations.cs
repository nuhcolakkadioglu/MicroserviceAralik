using MicroserviceAralik.Catalog.Mappings;
using MicroserviceAralik.Catalog.Services.BrandServices;
using MicroserviceAralik.Catalog.Services.CategoryService;
using MicroserviceAralik.Catalog.Services.ProductDetailDetailService;
using MicroserviceAralik.Catalog.Services.ProductDetailService;
using MicroserviceAralik.Catalog.Services.ProductService;
using MicroserviceAralik.Catalog.Settings;
using Microsoft.Extensions.Options;

namespace MicroserviceAralik.Catalog.Configurations;

public static class ServiceRegisterations
{
    public static void RegisteritaionService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));

        services.AddSingleton<IDatabaseSettings>(sp =>
           sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

        services.AddAutoMapper(typeof(GeneralMapping));

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductDetailDetailService, ProductDetailDetailService>();
    }
}
