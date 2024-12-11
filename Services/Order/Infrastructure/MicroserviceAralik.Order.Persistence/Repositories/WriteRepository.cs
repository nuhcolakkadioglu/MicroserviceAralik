using MicroserviceAralik.Order.Application.Interfaces;
using MicroserviceAralik.Order.Persistence.Context;

namespace MicroserviceAralik.Order.Persistence.Repositories;
public class WriteRepository<TEntity>(AppDbContext _context) : IWriteRepository<TEntity> where TEntity : class
{
    public async Task CreateAsync(TEntity model)
    {
        await _context.Set<TEntity>().AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        TEntity? data = await _context.Set<TEntity>().FindAsync(id);
        _context.Set<TEntity>().Remove(data);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity model)
    {
        _context.Set<TEntity>().Update(model);
        await _context.SaveChangesAsync();
    }
}
