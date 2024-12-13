using MicroserviceAralik.Services.Cargo.BusinessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DtoLayer.Dtos.OperationDtos;
using MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Services.Cargo.WebApi.Controllers;
[Route("api/[controller]")]
[Authorize]
[ApiController]
public class OperationsController(IOperationService _OperationService) : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "CargoReadAccess")]

    public async Task<IActionResult> GetAllOperations()
    {
        List<Operation> result = await _OperationService.GetAllAsync();
        return Ok(result);
    }



    [HttpGet("{id}")]
    [Authorize(Policy = "CargoReadAccess")]

    public async Task<IActionResult> GetOperationById(int id)
    {
        Operation result = await _OperationService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("GetOperationByBarcodeNumber")]
    [Authorize(Policy = "CargoReadAccess")]

    public async Task<IActionResult> GetOperationByBarcodeNumber(string barcodeNumber)
    {
        List<Operation> result = await _OperationService.GetOperationByBarcodeNumber(barcodeNumber);
        return Ok(result);
    }


    [HttpDelete("{id}")]
    [Authorize(Policy = "CargoFullAccess")]

    public async Task<IActionResult> DeleteOperation(int id)
    {
        await _OperationService.DeleteAsync(id);
        return Ok("Delete OK");
    }

    [HttpPost]
    [Authorize(Policy = "CargoFullAccess")]

    public async Task<IActionResult> CreateOperation(CreateOperationDto model)
    {

        await _OperationService.CreateAsync(new Operation
        {
            Barcode = model.Barcode,
            Description = model.Description,
            OperationTime = DateTime.Now,

        });
        return Ok("Create OK");
    }

    [HttpPut]
    [Authorize(Policy = "CargoFullAccess")]

    public async Task<IActionResult> UpdateOperation(UpdateOperationDto model)
    {
        await _OperationService.UpdateAsync(new Operation
        {
            Id = model.Id,
            Barcode = model.Barcode,
            Description = model.Description,
            OperationTime = DateTime.Now,

        });
        return Ok("Update OK");
    }


}
