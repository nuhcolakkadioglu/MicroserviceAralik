using MicroserviceAralik.Services.Cargo.BusinessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DtoLayer.Dtos.CompayDtos;
using MicroserviceAralik.Services.Cargo.DtoLayer.Dtos.CustomerDtos;
using MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Services.Cargo.WebApi.Controllers;
[Route("api/[controller]")]
[Authorize]
[ApiController]
public class CustomersController(ICustomerService _costomerService) : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "CargoReadAccess")]

    public async Task<IActionResult> GetAllCustomers()
    {
        List<Customer> result = await _costomerService.GetAllAsync();
        return Ok(result);
    }



    [HttpGet("{id}")]
    [Authorize(Policy = "CargoReadAccess")]

    public async Task<IActionResult> GetCustomerById(int id)
    {
        Customer result = await _costomerService.GetByIdAsync(id);
        return Ok(result);
    }



    [HttpDelete("{id}")]
    [Authorize(Policy = "CargoFullAccess")]

    public async Task<IActionResult> DeleteCustomer(int id)
    {
        await _costomerService.DeleteAsync(id);
        return Ok("Delete OK");
    }

    [HttpPost]
    [Authorize(Policy = "CargoFullAccess")]

    public async Task<IActionResult> CreateCustomer(CreateCustomerDto model)
    {

        await _costomerService.CreateAsync(new Customer
        {
            City = model.City,
            Address = model.Address,
            District = model.District,
            Email = model.Email,
            Name = model.Name,
            Phone = model.Phone,
            Surname = model.Surname,
            UserCostomerId = model.UserCostomerId,

        });
        return Ok("Create OK");
    }

    [HttpPut]
    [Authorize(Policy = "CargoFullAccess")]

    public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto model)
    {
        await _costomerService.UpdateAsync(new Customer
        {
            Id = model.Id,
            City = model.City,
            Address = model.Address,
            District = model.District,
            Email = model.Email,
            Name = model.Name,
            Phone = model.Phone,
            Surname = model.Surname,
            UserCostomerId = model.UserCostomerId,


        });
        return Ok("Update OK");
    }

}
