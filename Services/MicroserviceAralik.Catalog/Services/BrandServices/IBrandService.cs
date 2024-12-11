using MicroserviceAralik.Catalog.Dtos.BrandDtos;

namespace MicroserviceAralik.Catalog.Services.BrandServices;

public interface IBrandService
{
    Task<List<ResultBrandDto>> GetAllBrands();
    Task<ResultBrandDto> GetBrandById(string id);
    Task CreateBrand(CreateBrandDto model);
    Task UpdateBrand(UpdateBrandDto model);
    Task DeleteBrand(string id);
}
