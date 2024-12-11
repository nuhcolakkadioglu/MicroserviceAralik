namespace MicroserviceAralik.Order.Application.Interfaces;
public interface IWriteRepository<TEntity> where TEntity : class
{
    Task CreateAsync(TEntity model);
    Task UpdateAsync(TEntity model);
    Task DeleteAsync(int id);
}
