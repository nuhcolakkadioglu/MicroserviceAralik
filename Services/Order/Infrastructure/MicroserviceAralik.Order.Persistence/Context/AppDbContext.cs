using MicroserviceAralik.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Order.Persistence.Context;
public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=localhost,1481; initial catalog=OrderDb; user=sa; password=asdasdasd1+; TrustServerCertificate=True");
    }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Ordering> Orderings { get; set; }
    public DbSet<Address> Addresses { get; set; }
}
