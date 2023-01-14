using LPP.Entities;

namespace LPP.DAL.Contracts.Repositories
{
    public interface IAsyncBaseRepository<TEntity> where TEntity : EntityBase
    {
        public Task<TEntity?> GetByIdAsync(Guid id);

        public Task<IEnumerable<TEntity>> GetAllAsync();

        public Task<TEntity> AddAsync(TEntity entity);

        public Task<TEntity> UpdateAsync(TEntity entity);

        public Task DeleteAsync(TEntity entity);

        public Task DeleteByIdAsync(Guid id);

        public Task<bool> ExistsAsync(Guid id);

        public Task<int> CountAsync();

    }
}
