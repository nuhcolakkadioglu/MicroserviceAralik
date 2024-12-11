using MicroserviceAralik.Discount.Entities;

namespace MicroserviceAralik.Discount.Services.CouponRedemptionServices;

public interface IDiscountCouponRedemptionService
{
    Task<List<CouponRedemption>> GetAllCouponRedemption();
    Task<CouponRedemption> GetCouponRedemptionById(int id);

    Task<CouponRedemption> CreateCouponRedemption(CouponRedemption model);
    Task<CouponRedemption> UpdateCouponRedemption(CouponRedemption model);
    Task<bool> DeleteCouponRedemption(int id);
}
