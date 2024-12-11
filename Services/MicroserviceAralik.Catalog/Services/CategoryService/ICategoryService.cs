using MicroserviceAralik.Catalog.Dtos.CategoryDtos;

namespace MicroserviceAralik.Catalog.Services.CategoryService;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategories();
    Task<ResultCategoryDto> GetCategoryById(string id);
    Task CreateCategory(CreateCategoryDto model);
    Task UpdateCategory(UpdateCategoryDto model);
    Task DeleteCategory(string id);
}
