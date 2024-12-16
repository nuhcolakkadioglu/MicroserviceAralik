using MicroserviceAralik.Basket.Dtos;

namespace MicroserviceAralik.Basket.Services;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasket();
    Task SaveBasket(BasketTotalDto model);
    Task DeleteBasket();
}
