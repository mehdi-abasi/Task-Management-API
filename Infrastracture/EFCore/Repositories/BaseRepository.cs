using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.EFCore
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DbContext dbContext;
        public BaseRepository(DbContext _db)
        {
            dbContext = _db;
        }
        public async Task<int> CreateAsync(T entity)
        {
            await dbContext.AddAsync<T>(entity);
            await SaveAsync();
            return entity.ID;
        }

        public async Task DeleteAsync(T entity)
        {
            dbContext.Remove<T>(entity);
            await SaveAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIDAsync(int ID)
        {
            return await dbContext.FindAsync<T>(ID);
        }

        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

       
    }
}
