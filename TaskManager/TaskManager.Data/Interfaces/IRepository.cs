using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data.Interfaces
{
    public interface IRepository<TId, TEntity> where TEntity : class, new()
    {
        Task<TEntity> GetByIdAsync(TId Id);
        IQueryable<TEntity> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task DeleteAsync(TId entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        //bool IsExists(TId id);
    }
}
