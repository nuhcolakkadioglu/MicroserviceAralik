﻿using MicroserviceAralik.Order.Application.Interfaces;
using MicroserviceAralik.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Order.Persistence.Repositories;
public class ReadRepository<TEntity>(AppDbContext _context) : IReadRepository<TEntity> where TEntity : class
{
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }
}
