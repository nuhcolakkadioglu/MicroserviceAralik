using MicroserviceAralik.Catalog.Dtos.ProductDetailDtos;

namespace MicroserviceAralik.Catalog.Services.ProductDetailService;

public interface IProductDetailDetailService
{
    Task<List<ResultProductDetailDto>> GetAllProductDetails();
    Task<ResultProductDetailDto> GetProductDetailById(string id);
    Task CreateProductDetail(CreateProductDetailDto model);
    Task UpdateProductDetail(UpdateProductDetailDto model);
    Task DeleteProductDetail(string id);
}
