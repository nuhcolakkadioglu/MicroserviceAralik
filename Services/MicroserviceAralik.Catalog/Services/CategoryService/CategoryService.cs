using AutoMapper;
using MicroserviceAralik.Catalog.Dtos.CategoryDtos;
using MicroserviceAralik.Catalog.Entities;
using MicroserviceAralik.Catalog.Settings;
using MongoDB.Driver;

namespace MicroserviceAralik.Catalog.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _CategorysCollection;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        MongoClient client = new MongoClient(databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(databaseSettings.DatabaseName);
        _CategorysCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
    }
    public async Task CreateCategory(CreateCategoryDto model)
    {
        Category newCategory = _mapper.Map<Category>(model);

        await _CategorysCollection.InsertOneAsync(newCategory);

    }

    public async Task DeleteCategory(string id)
    {
        await _CategorysCollection.DeleteOneAsync(m => m.Id == id);
    }

    public async Task<List<ResultCategoryDto>> GetAllCategories()
    {
        List<Category> Categorys = await _CategorysCollection.Find(m => true).ToListAsync();

        List<ResultCategoryDto> CategoryAsDto = _mapper.Map<List<ResultCategoryDto>>(Categorys);

        return CategoryAsDto;
    }

    public async Task<ResultCategoryDto> GetCategoryById(string id)
    {
        Category Category = await _CategorysCollection.Find(m => m.Id == id).FirstOrDefaultAsync();

        ResultCategoryDto CategoryAsDto = _mapper.Map<ResultCategoryDto>(Category);

        return CategoryAsDto;
    }

    public async Task UpdateCategory(UpdateCategoryDto model)
    {
        Category newCategory = _mapper.Map<Category>(model);

        await _CategorysCollection.ReplaceOneAsync(m => m.Id == model.Id, newCategory);
    }
}
