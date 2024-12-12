using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceAralik.Services.Cargo.BusinessLayer.Abstract;
public interface IGenericService<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T model);
    Task UpdateAsync(T model);
    Task DeleteAsync(int id);
}
