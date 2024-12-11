using MicroserviceAralik.Catalog.Dtos.ProductDtos;

namespace MicroserviceAralik.Catalog.Services.ProductService;

public interface IProductService
{
    Task<List<ResultProductDto>> GetAllProducts();
    Task<ResultProductDto> GetProductById(string id);
    Task CreateProduct(CreateProductDto model);
    Task UpdateProduct(UpdateProductDto model);
    Task DeleteProduct(string id);
}
