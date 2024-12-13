using MicroserviceAralik.Services.Cargo.BusinessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DtoLayer.Dtos.OperationDtos;
using MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Services.Cargo.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OperationsController(IOperationService _OperationService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOperations()
    {
        var result = await _OperationService.GetAllAsync();
        return Ok(result);
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> GetOperationById(int id)
    {
        var result = await _OperationService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("GetOperationByBarcodeNumber")]
    public async Task<IActionResult> GetOperationByBarcodeNumber(string barcodeNumber)
    {
        var result = await _OperationService.GetOperationByBarcodeNumber(barcodeNumber);
        return Ok(result);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOperation(int id)
    {
        await _OperationService.DeleteAsync(id);
        return Ok("Delete OK");
    }

    [HttpPost]
    public async Task<IActionResult> CreateOperation(CreateOperationDto model)
    {

        await _OperationService.CreateAsync(new Operation
        {
           Barcode =model.Barcode,
           Description =model.Description,
           OperationTime =model.OperationTime

        });
        return Ok("Create OK");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOperation(UpdateOperationDto model)
    {
        await _OperationService.UpdateAsync(new Operation
        {
            Id = model.Id,
            Barcode = model.Barcode,
            Description = model.Description,
            OperationTime = model.OperationTime

        });
        return Ok("Update OK");
    }


}
