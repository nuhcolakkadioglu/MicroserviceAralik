using MicroserviceAralik.Inventory.Context;
using MicroserviceAralik.Inventory.Dtos.WarehouseDtos;
using MicroserviceAralik.Inventory.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Inventory.Services.WarehouseServices;

public interface IWarehouseService
{
    Task<List<ResultWarehouseDto>> GetAllWarehouses();
    Task CreateWarehouse(CreateWarehouseDto model);
}
public class WarehouseService(AppDbContext _context) : IWarehouseService
{
    public async Task CreateWarehouse(CreateWarehouseDto model)
    {
        Warehouse data = new Warehouse()
        {
            Location = model.Location,
            Name = model.Name,

        };

        await _context.AddAsync(data);

        await _context.SaveChangesAsync();
    }

    public async Task<List<ResultWarehouseDto>> GetAllWarehouses()
    {
        List<Warehouse> data = await _context.Warehouses.ToListAsync();

        return data.Select(m => new ResultWarehouseDto
        {
            Id = m.Id,
            Location = m.Location,
            Name = m.Name
        }).ToList();

    }
}
