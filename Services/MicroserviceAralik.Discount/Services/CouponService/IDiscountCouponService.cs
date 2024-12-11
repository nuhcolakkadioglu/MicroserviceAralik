
using MicroserviceAralik.Discount.Entities;

namespace MicroserviceAralik.Discount.Services.CouponService;

public interface IDiscountCouponService
{
    Task<List<Coupon>> GetAllCoupons();
    Task<Coupon> GetCouponById(int id);

    Task<Coupon> CreateCoupon(Coupon coupon);
    Task<Coupon> UpdateCoupon(Coupon coupon);
    Task<bool> DeleteCoupon(int id);

}
