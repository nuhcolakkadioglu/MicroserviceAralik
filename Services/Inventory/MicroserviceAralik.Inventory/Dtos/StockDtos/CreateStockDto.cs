using MicroserviceAralik.Inventory.Entities;

namespace MicroserviceAralik.Inventory.Dtos.StockDtos;

public class CreateStockDto
{

    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public int WarehouseId { get; set; }
}

public class ResutlStockDto : CreateStockDto
{
    public int Id { get; set; }
    public DateTime lastUpdate { get; set; }

}