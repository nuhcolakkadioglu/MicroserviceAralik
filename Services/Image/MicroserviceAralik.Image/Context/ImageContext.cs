using MicroserviceAralik.Image.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Image.Context;

public class ImageContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;port=3306; database=ImageDb; user=root; password=asdasdasd1+");
    }

    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<BrandImage> BrandImages { get; set; }
}
