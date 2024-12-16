namespace MicroserviceAralik.Basket.Dtos;

public class BasketItemsDto
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string ProductImageUrl { get; set; }
}
