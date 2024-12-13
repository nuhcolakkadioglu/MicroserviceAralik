using MicroserviceAralik.Services.Cargo.BusinessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DtoLayer.Dtos.CompayDtos;
using MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Services.Cargo.WebApi.Controllers;
[Route("api/[controller]")]
[Authorize]
[ApiController]
public class CompaniesController(ICompanyService _companyService) : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "CargoReadAccess")]
    public async Task<IActionResult> GetAllCompanies()
    {
        List<Company> result = await _companyService.GetAllAsync();
        return Ok(result);
    }



    [HttpGet("{id}")]
    [Authorize(Policy = "CargoReadAccess")]
    public async Task<IActionResult> GetCompanyById(int id)
    {
        Company result = await _companyService.GetByIdAsync(id);
        return Ok(result);
    }



    [HttpDelete("{id}")]
    [Authorize(Policy = "CargoFullAccess")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        await _companyService.DeleteAsync(id);
        return Ok("Delete OK");
    }

    [HttpPost]
    [Authorize(Policy = "CargoFullAccess")]

    public async Task<IActionResult> CreateCompany(CreateCompanyDto model)
    {

        await _companyService.CreateAsync(new Company
        {
            Name = model.Name,


        });
        return Ok("Create OK");
    }

    [HttpPut]
    [Authorize(Policy = "CargoFullAccess")]

    public async Task<IActionResult> UpdateCompany(UpdateCompanyDto model)
    {
        await _companyService.UpdateAsync(new Company
        {
            Id = model.Id,
            Name = model.Name,

        });
        return Ok("Update OK");
    }


}
