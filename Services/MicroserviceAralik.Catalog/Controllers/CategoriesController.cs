using MicroserviceAralik.Catalog.Dtos.CategoryDtos;
using MicroserviceAralik.Catalog.Services.CategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Catalog.Controllers;
[Route("api/[controller]")]
[Authorize]
[ApiController]
public class CategoriesController(ICategoryService _categoryService) : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "CatalogReadAccess")]
    public async Task<IActionResult> GetAllCategories()
    {
        List<ResultCategoryDto> data = await _categoryService.GetAllCategories();
        return Ok(data);

    }

    [HttpGet("{id}")]
    [Authorize(Policy = "CatalogReadAccess")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        ResultCategoryDto data = await _categoryService.GetCategoryById(id);
        return Ok(data);

    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "CatalogFullAccess")]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _categoryService.DeleteCategory(id);
        return Ok();

    }

    [HttpPost]
    [Authorize(Policy = "CatalogFullAccess")]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto model)
    {
        await _categoryService.CreateCategory(model);
        return Ok();

    }
    [HttpPut]
    [Authorize(Policy = "CatalogFullAccess")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto model)
    {
        await _categoryService.UpdateCategory(model);
        return Ok();

    }
}
