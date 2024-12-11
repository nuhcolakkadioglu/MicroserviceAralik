using MicroserviceAralik.Discount.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Discount.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=localhost,1480; initial catalog=DiscountDb; user=sa; password=asdasdasd1+; TrustServerCertificate=True");
    }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<CouponRedemption> CouponRedemptions { get; set; }
}
