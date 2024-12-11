using MicroserviceAralik.Catalog.Dtos.BrandDtos;
using MicroserviceAralik.Catalog.Services.BrandServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Catalog.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BrandsController(IBrandService _brandService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllBrands()
    {
        List<ResultBrandDto> data = await _brandService.GetAllBrands();
        return Ok(data);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrandById(string id)
    {
        ResultBrandDto data = await _brandService.GetBrandById(id);
        return Ok(data);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand(string id)
    {
        await _brandService.DeleteBrand(id);
        return Ok();

    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandDto model)
    {
        await _brandService.CreateBrand(model);
        return Ok();

    }
    [HttpPut]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto model)
    {
        await _brandService.UpdateBrand(model);
        return Ok();

    }
}
