namespace MicroserviceAralik.Inventory.Entities;

public class Stock
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public Warehouse Warehouse { get; set; }
    public int WarehouseId { get; set; }
    public DateTime lastUpdate { get; set; }
}
