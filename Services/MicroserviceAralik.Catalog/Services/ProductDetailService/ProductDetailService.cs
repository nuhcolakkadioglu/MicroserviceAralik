using AutoMapper;
using MicroserviceAralik.Catalog.Dtos.ProductDetailDtos;
using MicroserviceAralik.Catalog.Entities;
using MicroserviceAralik.Catalog.Services.ProductDetailService;
using MicroserviceAralik.Catalog.Settings;
using MongoDB.Driver;

namespace MicroserviceAralik.Catalog.Services.ProductDetailDetailService;

public class ProductDetailDetailService : IProductDetailDetailService
{
    private readonly IMongoCollection<ProductDetail> _ProductDetailsCollection;
    private readonly IMapper _mapper;

    public ProductDetailDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        MongoClient client = new MongoClient(databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(databaseSettings.DatabaseName);
        _ProductDetailsCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
    }
    public async Task CreateProductDetail(CreateProductDetailDto model)
    {
        ProductDetail newProductDetail = _mapper.Map<ProductDetail>(model);

        await _ProductDetailsCollection.InsertOneAsync(newProductDetail);

    }

    public async Task DeleteProductDetail(string id)
    {
        await _ProductDetailsCollection.DeleteOneAsync(m => m.Id == id);
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetails()
    {
        List<ProductDetail> ProductDetails = await _ProductDetailsCollection.Find(m => true).ToListAsync();

        List<ResultProductDetailDto> ProductDetailAsDto = _mapper.Map<List<ResultProductDetailDto>>(ProductDetails);

        return ProductDetailAsDto;
    }

    public async Task<ResultProductDetailDto> GetProductDetailById(string id)
    {
        ProductDetail ProductDetail = await _ProductDetailsCollection.Find(m => m.Id == id).FirstOrDefaultAsync();

        ResultProductDetailDto ProductDetailAsDto = _mapper.Map<ResultProductDetailDto>(ProductDetail);

        return ProductDetailAsDto;
    }

    public async Task UpdateProductDetail(UpdateProductDetailDto model)
    {
        ProductDetail newProductDetail = _mapper.Map<ProductDetail>(model);

        await _ProductDetailsCollection.ReplaceOneAsync(m => m.Id == model.Id, newProductDetail);
    }
}
