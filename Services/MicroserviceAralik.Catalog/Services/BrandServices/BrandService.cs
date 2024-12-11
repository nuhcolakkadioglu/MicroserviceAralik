using AutoMapper;
using MicroserviceAralik.Catalog.Dtos.BrandDtos;
using MicroserviceAralik.Catalog.Entities;
using MicroserviceAralik.Catalog.Settings;
using MongoDB.Driver;

namespace MicroserviceAralik.Catalog.Services.BrandServices;

public class BrandService : IBrandService
{
    private readonly IMongoCollection<Brand> _brandsCollection;
    private readonly IMapper _mapper;

    public BrandService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        MongoClient client = new MongoClient(databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(databaseSettings.DatabaseName);
        _brandsCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
    }
    public async Task CreateBrand(CreateBrandDto model)
    {
        Brand newBrand = _mapper.Map<Brand>(model);

        await _brandsCollection.InsertOneAsync(newBrand);

    }

    public async Task DeleteBrand(string id)
    {
        await _brandsCollection.DeleteOneAsync(m => m.Id == id);
    }

    public async Task<List<ResultBrandDto>> GetAllBrands()
    {
        List<Brand> brands = await _brandsCollection.Find(m => true).ToListAsync();

        List<ResultBrandDto> brandAsDto = _mapper.Map<List<ResultBrandDto>>(brands);

        return brandAsDto;
    }

    public async Task<ResultBrandDto> GetBrandById(string id)
    {
        Brand brand = await _brandsCollection.Find(m => m.Id == id).FirstOrDefaultAsync();

        ResultBrandDto brandAsDto = _mapper.Map<ResultBrandDto>(brand);

        return brandAsDto;
    }

    public async Task UpdateBrand(UpdateBrandDto model)
    {
        Brand newBrand = _mapper.Map<Brand>(model);

        await _brandsCollection.ReplaceOneAsync(m => m.Id == model.Id, newBrand);
    }
}
