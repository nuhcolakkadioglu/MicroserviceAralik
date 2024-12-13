using MicroserviceAralik.Catalog.Dtos.ProductDetailDtos;
using MicroserviceAralik.Catalog.Services.ProductDetailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Catalog.Controllers;
[Route("api/[controller]")]
[Authorize]
[ApiController]
public class ProductsDetailsController(IProductDetailDetailService _categoryService) : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "CatalogReadAccess")]
    public async Task<IActionResult> GetAllProductDetails()
    {
        List<ResultProductDetailDto> data = await _categoryService.GetAllProductDetails();
        return Ok(data);

    }

    [HttpGet("{id}")]
    [Authorize(Policy = "CatalogReadAccess")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        ResultProductDetailDto data = await _categoryService.GetProductDetailById(id);
        return Ok(data);

    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "CatalogFullAccess")]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await _categoryService.DeleteProductDetail(id);
        return Ok();

    }

    [HttpPost]
    [Authorize(Policy = "CatalogFullAccess")]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto model)
    {
        await _categoryService.CreateProductDetail(model);
        return Ok();

    }
    [HttpPut]
    [Authorize(Policy = "CatalogFullAccess")]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto model)
    {
        await _categoryService.UpdateProductDetail(model);
        return Ok();

    }
}
