namespace MicroserviceAralik.Catalog.Settings;

public class DatabaseSettings : IDatabaseSettings
{
    public required string BrandCollectionName { get; set; }
    public required string CategoryCollectionName { get; set; }
    public required string ProductCollectionName { get; set; }
    public required string ProductDetailCollectionName { get; set; }

    public required string ConnectionString { get; set; }
    public required string DatabaseName { get; set; }
}
