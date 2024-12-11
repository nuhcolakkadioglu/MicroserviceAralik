using MicroserviceAralik.Discount.Context;
using MicroserviceAralik.Discount.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Discount.Services.CouponService;

public class DiscountCouponService(AppDbContext _context) : IDiscountCouponService
{
    public async Task<Coupon> CreateCoupon(Coupon coupon)
    {
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Coupon> result = await _context.Coupons.AddAsync(coupon);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> DeleteCoupon(int id)
    {
        Coupon? result = await _context.Coupons.FindAsync(id);
        _context.Coupons.Remove(result!);
        int sonuc = await _context.SaveChangesAsync();
        return sonuc > 0 ? true : false;
    }

    public async Task<List<Coupon>> GetAllCoupons()
    {
        List<Coupon> result = await _context.Coupons.ToListAsync();
        return result;
    }

    public async Task<Coupon> GetCouponById(int id)
    {
        Coupon? result = await _context.Coupons.FindAsync(id);
        return result!;
    }

    public async Task<Coupon> UpdateCoupon(Coupon coupon)
    {
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Coupon> x = _context.Coupons.Update(coupon);
        await _context.SaveChangesAsync();

        return x.Entity;

    }
}
