using MicroserviceAralik.Inventory.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Inventory.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("server=localhost,1484; initial catalog=InventoryDb; user=sa; password=asdasdasd1+; TrustServerCertificate=True");

    }

    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
}
