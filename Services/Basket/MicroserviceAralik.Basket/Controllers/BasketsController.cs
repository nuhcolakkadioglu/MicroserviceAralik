using MicroserviceAralik.Basket.Dtos;
using MicroserviceAralik.Basket.Services;
using MicroserviceAralik.Basket.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MicroserviceAralik.Basket.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BasketsController : ControllerBase
{

    private readonly IBasketService _basketService;

    public BasketsController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpGet]
    [Authorize(Policy = "BasketReadAccess")]
    public async Task<IActionResult> GetBasket()
    {

     var data =   await _basketService.GetBasket();

        return Ok(data);
    }

    [HttpPost]
    [Authorize(Policy = "BasketFullAccess")]
    public async Task<IActionResult> SaveBasket(BasketTotalDto model)
    {

        await _basketService.SaveBasket(model);

        return Ok("Created");
    }

    [HttpDelete]
    [Authorize(Policy = "BasketFullAccess")]
    public async Task<IActionResult> DeleteBasket()
    {

        await _basketService.DeleteBasket();

        return Ok("Delete");
    }
}
