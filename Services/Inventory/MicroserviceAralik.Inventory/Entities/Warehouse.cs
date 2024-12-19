namespace MicroserviceAralik.Inventory.Entities;

public class Warehouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public List<Stock> Stocks { get; set; }
}
