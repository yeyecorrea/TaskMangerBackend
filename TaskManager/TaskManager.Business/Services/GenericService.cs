using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Interfaces;
using TaskManager.Data.Interfaces;

namespace TaskManager.Business.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class, new() where TDto : class
    {
        private readonly IRepository<int, TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IRepository<int, TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<TEntity> CreateAsync(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);
            var newEntity = _repository.AddAsync(entity);
            return newEntity;
        }

        public async Task DeleteAsync(int Id)
        {
            await _repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync().ToListAsync();
            return result;
        }

        public Task<TEntity> GetByIdAsync(int Id)
        {
            var result = _repository.GetByIdAsync(Id);
            return result;
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = _repository.UpdateAsync(entity);
            return result;
        }
    }
}
