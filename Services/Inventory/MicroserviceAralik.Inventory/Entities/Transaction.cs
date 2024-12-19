namespace MicroserviceAralik.Inventory.Entities;

public class Transaction
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public string Type { get; set; } //in or aut
    public DateTime EventTime { get; set; }
    public string Description { get; set; }
}
