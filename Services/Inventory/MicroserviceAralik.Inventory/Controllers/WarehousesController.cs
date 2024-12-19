using MicroserviceAralik.Inventory.Dtos.WarehouseDtos;
using MicroserviceAralik.Inventory.Services.WarehouseServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Inventory.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WarehousesController(IWarehouseService _warehouseService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _warehouseService.GetAllWarehouses());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateWarehouseDto model)
    {
        await _warehouseService.CreateWarehouse(model);
        return Ok("Created");
    }
}
