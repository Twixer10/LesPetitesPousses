using LPP.Entities;

namespace LPP.DAL.Contracts.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : EntityBase
    {
        public TEntity? GetById(Guid id);

        public IEnumerable<TEntity> GetAll();

        public TEntity Add(TEntity entity);

        public TEntity Update(TEntity entity);

        public void Delete(TEntity entity);

        public void DeleteById(Guid id);

        public bool Exists(Guid id);

        public int Count();
    }
}