using MicroserviceAralik.Inventory.Context;
using MicroserviceAralik.Inventory.Dtos.StockDtos;
using MicroserviceAralik.Inventory.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Inventory.Services.StockServices;

public interface IStockService
{
    Task CreateStock(CreateStockDto model);
    Task<List<ResutlStockDto>> GetAllStock();
    Task<bool> ReserveInventory(string productId, int quantity);
    Task<bool> RollbackInventory(string productId, int quantity);
}
public class StockService(AppDbContext _context) : IStockService
{
    public async Task CreateStock(CreateStockDto model)
    {
        Stock stokc = new Stock()
        {
            lastUpdate = DateTime.UtcNow,
            ProductId = model.ProductId,
            Quantity = model.Quantity,
            WarehouseId = model.WarehouseId
        };

        await _context.AddAsync(stokc);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ResutlStockDto>> GetAllStock()
    {
        List<Stock> data = await _context.Stocks.ToListAsync();

        return data.Select(m => new ResutlStockDto
        {
            Id = m.Id,
            ProductId = m.ProductId,
            Quantity = m.Quantity,
            WarehouseId = m.WarehouseId,
            lastUpdate = m.lastUpdate
        }).ToList();
    }

    public async Task<bool> ReserveInventory(string productId, int quantity)
    {
        Stock? product = await _context.Stocks.FirstOrDefaultAsync(m => m.ProductId == productId);

        if (product is null || product.Quantity < quantity)
            return false;

        product.Quantity -= quantity;

        await _context.SaveChangesAsync();

        return true;


    }

    public async Task<bool> RollbackInventory(string productId, int quantity)
    {
        Stock? product = await _context.Stocks.FirstOrDefaultAsync(m => m.ProductId == productId);

        if (product is null)
            return false;

        product.Quantity += quantity;

        await _context.SaveChangesAsync();

        return true;
    }
}
