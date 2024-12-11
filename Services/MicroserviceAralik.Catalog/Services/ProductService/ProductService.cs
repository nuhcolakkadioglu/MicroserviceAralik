using AutoMapper;
using MicroserviceAralik.Catalog.Dtos.ProductDtos;
using MicroserviceAralik.Catalog.Entities;
using MicroserviceAralik.Catalog.Settings;
using MongoDB.Driver;

namespace MicroserviceAralik.Catalog.Services.ProductService;

public class ProductService : IProductService
{
    private readonly IMongoCollection<Product> _ProductsCollection;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        MongoClient client = new MongoClient(databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(databaseSettings.DatabaseName);
        _ProductsCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
    }
    public async Task CreateProduct(CreateProductDto model)
    {
        Product newProduct = _mapper.Map<Product>(model);

        await _ProductsCollection.InsertOneAsync(newProduct);

    }

    public async Task DeleteProduct(string id)
    {
        await _ProductsCollection.DeleteOneAsync(m => m.Id == id);
    }

    public async Task<List<ResultProductDto>> GetAllProducts()
    {
        List<Product> Products = await _ProductsCollection.Find(m => true).ToListAsync();

        List<ResultProductDto> ProductAsDto = _mapper.Map<List<ResultProductDto>>(Products);

        return ProductAsDto;
    }

    public async Task<ResultProductDto> GetProductById(string id)
    {
        Product Product = await _ProductsCollection.Find(m => m.Id == id).FirstOrDefaultAsync();

        ResultProductDto ProductAsDto = _mapper.Map<ResultProductDto>(Product);

        return ProductAsDto;
    }

    public async Task UpdateProduct(UpdateProductDto model)
    {
        Product newProduct = _mapper.Map<Product>(model);

        await _ProductsCollection.ReplaceOneAsync(m => m.Id == model.Id, newProduct);
    }
}
