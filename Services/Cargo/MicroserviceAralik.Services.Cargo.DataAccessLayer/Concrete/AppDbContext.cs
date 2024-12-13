using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroserviceAralik.Services.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Services.Cargo.DataAccessLayer.Concrete;
public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=localhost,1483; initial catalog=CargoDb; user=sa; password=asdasdasd1+; TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Customer>()
                 .HasMany(m => m.SentCargoDetails).WithOne(m => m.SenderCustomer).HasForeignKey(m => m.SenderCustomerId);

        modelBuilder.Entity<Customer>()
                 .HasMany(m => m.ReceivedCargoDetails).WithOne(m => m.ReceiverCustomer).HasForeignKey(m => m.ReceiverCustomerId);

    }

    public DbSet<CargoDetail> CargoDetails { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Operation> Operations { get; set; }
}
