namespace TaskManager.Business.Interfaces
{
    public interface IGenericService<TEntity, TDto> where TEntity : class, new() where TDto : class
    {
        Task<TEntity> CreateAsync(TDto dto);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int Id);
        Task<TEntity> UpdateAsync(TEntity dto);
        Task DeleteAsync(int Id);

    }
}
