using MicroserviceAralik.Discount.Context;
using MicroserviceAralik.Discount.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Discount.Services.CouponRedemptionServices;

public class DiscountCouponRedemptionService(AppDbContext _context) : IDiscountCouponRedemptionService
{
    public async Task<CouponRedemption> CreateCouponRedemption(CouponRedemption model)
    {
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<CouponRedemption> add = await _context.CouponRedemptions.AddAsync(model);

        await _context.SaveChangesAsync();

        return add.Entity;

    }

    public async Task<bool> DeleteCouponRedemption(int id)
    {
        CouponRedemption? data = await _context.CouponRedemptions.FindAsync(id);
        _context.CouponRedemptions.Remove(data);

        await _context.SaveChangesAsync();
        return true;
    }

    public Task<List<CouponRedemption>> GetAllCouponRedemption()
    {
        Task<List<CouponRedemption>> data = _context.CouponRedemptions.ToListAsync();

        return data;
    }

    public async Task<CouponRedemption> GetCouponRedemptionById(int id)
    {
        CouponRedemption? data = await _context.CouponRedemptions.FindAsync(id);

        return data;
    }

    public async Task<CouponRedemption> UpdateCouponRedemption(CouponRedemption model)
    {
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<CouponRedemption> up = _context.CouponRedemptions.Update(model);

        await _context.SaveChangesAsync();

        return up.Entity;

    }
}
