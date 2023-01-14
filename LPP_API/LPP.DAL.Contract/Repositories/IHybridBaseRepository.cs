using LPP.Entities;

namespace LPP.DAL.Contracts.Repositories
{
    public interface IHybridBaseRepository<TEntity> : IBaseRepository<TEntity>, IAsyncBaseRepository<TEntity> where TEntity : EntityBase
    {

    }
}
