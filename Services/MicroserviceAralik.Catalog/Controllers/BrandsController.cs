using MicroserviceAralik.Catalog.Dtos.BrandDtos;
using MicroserviceAralik.Catalog.Services.BrandServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Catalog.Controllers;
[Route("api/[controller]")]
[Authorize]
[ApiController]
public class BrandsController(IBrandService _brandService) : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "CatalogReadAccess")]
    public async Task<IActionResult> GetAllBrands()
    {
        List<ResultBrandDto> data = await _brandService.GetAllBrands();
        return Ok(data);

    }
    [Authorize(Policy = "CatalogReadAccess")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrandById(string id)
    {
        ResultBrandDto data = await _brandService.GetBrandById(id);
        return Ok(data);

    }
    [Authorize(Policy = "CatalogFullAccess")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand(string id)
    {
        await _brandService.DeleteBrand(id);
        return Ok();

    }
    [Authorize(Policy = "CatalogFullAccess")]
    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandDto model)
    {
        await _brandService.CreateBrand(model);
        return Ok();

    }
    [Authorize(Policy = "CatalogFullAccess")]
    [HttpPut]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto model)
    {
        await _brandService.UpdateBrand(model);
        return Ok();

    }
}
