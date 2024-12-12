using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Services.Cargo.DataAccessLayer.Repositories;
public class GenericRepository<T>  : IGenericDal<T> where T : class
{
    protected readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T model)
    {
        await _context.Set<T>().AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {

        var data = await _context.Set<T>().FindAsync(id);
        _context.Set<T>().Remove(data);
        await _context.SaveChangesAsync();

    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();

    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T model)
    {
        _context.Set<T>().Update(model);
        await _context.SaveChangesAsync();
    }
}
