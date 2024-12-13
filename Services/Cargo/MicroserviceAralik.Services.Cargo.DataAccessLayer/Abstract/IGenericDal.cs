namespace MicroserviceAralik.Services.Cargo.DataAccessLayer.Abstract;
public interface IGenericDal<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T model);
    Task UpdateAsync(T model);
    Task DeleteAsync(int id);

}
