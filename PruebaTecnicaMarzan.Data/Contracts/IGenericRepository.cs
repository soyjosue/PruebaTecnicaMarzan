using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaMarzan.Data.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByIDAsync(int id);
        Task<bool> CreateAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<bool> RemoveAsync(T entity);
    }
}
