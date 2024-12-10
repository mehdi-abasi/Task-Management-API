using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IBaseRepository<T>  where T : BaseEntity
    {
        Task<int> CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIDAsync(int ID);
        Task<List<T>> GetAllAsync();
        Task<int> SaveAsync();
    }
}
