using MicroserviceAralik.Services.Cargo.BusinessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Services.Cargo.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController(ICargoDetailService _cargoDetailService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCargoDetails()
    {
        var result = await _cargoDetailService.GetAllAsync();
        return Ok(result);
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoDetailById(int id)
    {
        var result = await _cargoDetailService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("GetSendCargoDetails")]
    public async Task<IActionResult> GetSendCargoDetailsByCustomerId(int id)
    {
        var result = await _cargoDetailService.GetSendCargoDetailsByCustomerId(id);
        return Ok(result);
    }

    [HttpGet("GetReceivedCargoDetails")]
    public async Task<IActionResult> GetReceivedCargoDetailByCustomerId(int id)
    {
        var result = await _cargoDetailService.GetReceivedCargoDetailByCustomerId(id);
        return Ok(result);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCargoDetail(int id)
    {
        await _cargoDetailService.DeleteAsync(id);
        return Ok("Delete OK");
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto model)
    {

        await _cargoDetailService.CreateAsync(new CargoDetail
        {
            Barcode = model.Barcode,
            CompanyId = model.CompanyId,
            ReceiverCustomerId = model.ReceiverCustomerId,
            SenderCustomerId = model.SenderCustomerId

        });
        return Ok("Create OK");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto model)
    {
        await _cargoDetailService.UpdateAsync(new CargoDetail
        {
            Id = model.Id,
            Barcode = model.Barcode,
            CompanyId = model.CompanyId,
            ReceiverCustomerId = model.ReceiverCustomerId,
            SenderCustomerId = model.SenderCustomerId

        });
        return Ok("Update OK");
    }





}
