namespace MicroserviceAralik.Basket.Dtos;

public class BasketTotalDto
{
    public string DiscountCode { get; set; }
    public int DiscountRate { get; set; }
    public List<BasketItemsDto> BasketItems { get; set; }
    public decimal TotalPrice { get => !BasketItems.Any() ? BasketItems.Sum(m => m.Quantity * m.Price):0; }
}
