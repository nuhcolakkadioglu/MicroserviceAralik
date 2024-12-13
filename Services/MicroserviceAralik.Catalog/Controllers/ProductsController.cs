using MicroserviceAralik.Catalog.Dtos.ProductDtos;
using MicroserviceAralik.Catalog.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Catalog.Controllers;
[Route("api/[controller]")]
[Authorize]
[ApiController]
public class ProductsController(IProductService _categoryService) : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "CatalogReadAccess")]
    public async Task<IActionResult> GetAllProducts()
    {
        List<ResultProductDto> data = await _categoryService.GetAllProducts();
        return Ok(data);

    }

    [HttpGet("{id}")]
    [Authorize(Policy = "CatalogReadAccess")]
    public async Task<IActionResult> GetProductById(string id)
    {
        ResultProductDto data = await _categoryService.GetProductById(id);
        return Ok(data);

    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "CatalogFullAccess")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _categoryService.DeleteProduct(id);
        return Ok();

    }

    [HttpPost]
    [Authorize(Policy = "CatalogFullAccess")]
    public async Task<IActionResult> CreateProduct(CreateProductDto model)
    {
        await _categoryService.CreateProduct(model);
        return Ok();

    }
    [HttpPut]
    [Authorize(Policy = "CatalogFullAccess")]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto model)
    {
        await _categoryService.UpdateProduct(model);
        return Ok();

    }
}
