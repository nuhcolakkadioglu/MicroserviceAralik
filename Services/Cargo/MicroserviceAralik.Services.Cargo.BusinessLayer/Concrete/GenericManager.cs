using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroserviceAralik.Services.Cargo.BusinessLayer.Abstract;
using MicroserviceAralik.Services.Cargo.DataAccessLayer.Abstract;

namespace MicroserviceAralik.Services.Cargo.BusinessLayer.Concrete;
public class GenericManager<T> : IGenericService<T> where T : class
{
    protected readonly IGenericDal<T> _genericDal;

    public GenericManager(IGenericDal<T> genericDal)
    {
        _genericDal = genericDal;
    }

    public async Task CreateAsync(T model)
    {
        await _genericDal.CreateAsync(model);
    }

    public async Task DeleteAsync(int id)
    {
        await _genericDal.DeleteAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _genericDal.GetAllAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _genericDal.GetByIdAsync(id);
    }

    public async Task UpdateAsync(T model)
    {
        await _genericDal.UpdateAsync(model);
    }
}
