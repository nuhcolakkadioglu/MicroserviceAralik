using MicroserviceAralik.Message.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Message.Dal.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("server=localhost; port=5432; database=MessageDb; User Id=user; Password=asdasdasd1+");
    }

    public DbSet<UserMessage> UserMessages { get; set; }
}
