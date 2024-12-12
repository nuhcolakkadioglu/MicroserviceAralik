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
    public async Task<IActionResult> GetAllCategories()
    {
        List<ResultCategoryDto> data = await _categoryService.GetAllCategories();
        return Ok(data);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        ResultCategoryDto data = await _categoryService.GetCategoryById(id);
        return Ok(data);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _categoryService.DeleteCategory(id);
        return Ok();

    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto model)
    {
        await _categoryService.CreateCategory(model);
        return Ok();

    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto model)
    {
        await _categoryService.UpdateCategory(model);
        return Ok();

    }
}
