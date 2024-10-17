using Microsoft.EntityFrameworkCore;
using TaskManager.Data.DataContext;
using TaskManager.Data.Interfaces;

namespace TaskManager.Data.Repositories
{
    public class Repository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : class, new()
    {
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
            
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception($"{nameof(AddAsync)} No se pudo gurardar: {ex.Message} ");
            }
        }

        public async Task DeleteAsync(TId id)
        {
            try
            {
                var entity = await _context.FindAsync<TEntity>(id);
                _context.Remove<TEntity>(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"{nameof(DeleteAsync)} Nose puede borrar: {ex.Message}");
            }
            
        }

        public IQueryable<TEntity> GetAllAsync()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($": {ex.Message}");
                
            }
            
        }

        public async Task<TEntity> GetByIdAsync(TId Id)
        {
            var entity = await _context.FindAsync<TEntity>(Id);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            try
            {
                _context.ChangeTracker.Clear();
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception($"{nameof(AddAsync)} No se pudo actualizar: {ex.Message}");
            }
        }

        //public async Task<bool> IsExists(TId id)
        //{
        //    return await _context.Any<TEntity>(e => e.Id == id);
        //}
    }
}
