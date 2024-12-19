using MicroserviceAralik.Inventory.Dtos.StockDtos;
using MicroserviceAralik.Inventory.Services.StockServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Inventory.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StocksController(IStockService _stockService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateStock(CreateStockDto model)
    {
        await _stockService.CreateStock(model);

        return Ok("CreateStock");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<ResutlStockDto> data = await _stockService.GetAllStock();

        return Ok(data);
    }

    [HttpGet("ReserveInventory")]
    public async Task<IActionResult> ReserveInventory(string productId, int quantity)
    {
        bool data = await _stockService.ReserveInventory(productId, quantity);

        return Ok(data);
    }

    [HttpGet("RollbackInventory")]
    public async Task<IActionResult> RollbackInventory(string productId, int quantity)
    {
        bool data = await _stockService.RollbackInventory(productId, quantity);

        return Ok(data);
    }
}
