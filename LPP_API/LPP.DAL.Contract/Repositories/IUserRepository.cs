using LPP.Entities;

namespace LPP.DAL.Contracts.Repositories
{
    public interface IUserRepository : IHybridBaseRepository<User>
    {
        public Task<User?> GetByEmailAsync(string email);
        public Task<User?> GetByPseudoAsync(string pseudo);

    }
}
