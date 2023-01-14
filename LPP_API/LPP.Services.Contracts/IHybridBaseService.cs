using LPP.Entities;

namespace LPP.Services.Contracts
{
    public interface IHybridBaseService<TEntity> : IAsyncBaseService<TEntity> , IBaseService<TEntity> where TEntity : EntityBase
    {

    }
}
