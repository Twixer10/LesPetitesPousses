using LPP.DAL.Contracts.Repositories;
using LPP.Entities;

namespace LPP.DAL.Repositories
{
    public class SanctionRepository : BaseRepository<Sanction>, ISanctionRepository
    {
        public SanctionRepository(LppDbContext context) : base(context)
        {
        }
    }
}
