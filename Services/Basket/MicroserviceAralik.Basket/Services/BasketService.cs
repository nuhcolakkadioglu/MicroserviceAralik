using System.Reflection;
using System.Security.Claims;
using System.Text.Json;
using MicroserviceAralik.Basket.Dtos;
using MicroserviceAralik.Basket.Settings;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace MicroserviceAralik.Basket.Services;

public class BasketService : IBasketService
{
   // private readonly RedisSettings _redisSettings;
    private readonly RedisService _redisService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    //IOptions<RedisSettings> redisSettings,
    public BasketService( IHttpContextAccessor httpContextAccessor, RedisService redisService)
    {
       // _redisSettings = redisSettings.Value;
        _httpContextAccessor = httpContextAccessor;
        _redisService = redisService;
    }

    public async Task DeleteBasket()
    {

        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        await _redisService.GetDatabase().KeyDeleteAsync(userId);
    }

    public async Task<BasketTotalDto> GetBasket()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        var getBasket =await _redisService.GetDatabase().StringGetAsync(userId);
       
        if(getBasket.IsNull)
        {
            throw new Exception("HASHDHASDH");
        }
     

        return JsonSerializer.Deserialize<BasketTotalDto>(getBasket);

     }

    public async Task SaveBasket(BasketTotalDto model)
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        await _redisService.GetDatabase().StringSetAsync(userId,JsonSerializer.Serialize(model));
    }
}
