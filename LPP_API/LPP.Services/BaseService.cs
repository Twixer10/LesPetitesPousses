using LPP.DAL.Contracts.Repositories;
using LPP.Entities;
using LPP.Services.Contracts;

namespace LPP.Services
{
    public class BaseService<TEntity> : IHybridBaseService<TEntity> where TEntity : EntityBase
    {
        private readonly IHybridBaseRepository<TEntity> _repository;

        public BaseService(IHybridBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual TEntity? GetById(Guid id)
            => _repository.GetById(id);

        public virtual IEnumerable<TEntity> GetAll()
            => _repository.GetAll();

        public virtual TEntity Add(TEntity entity)
            => _repository.Add(entity);

        public virtual TEntity Update(TEntity entity)
            => _repository.Update(entity);

        public virtual void Delete(TEntity entity)
            => _repository.Delete(entity);

        public virtual void DeleteById(Guid id)
            => _repository.DeleteById(id);

        public virtual bool Exists(Guid id)
            => _repository.Exists(id);

        public virtual int Count()
            => _repository.Count();

        public virtual Task<TEntity?> GetByIdAsync(Guid id)
            => _repository.GetByIdAsync(id);

        public virtual Task<IEnumerable<TEntity>> GetAllAsync()
            => _repository.GetAllAsync();

        public virtual Task<TEntity> AddAsync(TEntity entity)
            => _repository.AddAsync(entity);

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
            => _repository.UpdateAsync(entity);

        public virtual Task DeleteAsync(TEntity entity)
            => _repository.DeleteAsync(entity);

        public virtual Task DeleteByIdAsync(Guid id)
            => _repository.DeleteByIdAsync(id);

        public virtual Task<bool> ExistsAsync(Guid id)
            => _repository.ExistsAsync(id);

        public virtual Task<int> CountAsync()
            => _repository.CountAsync();
    }
}
