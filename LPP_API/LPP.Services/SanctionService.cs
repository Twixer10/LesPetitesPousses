using LPP.DAL.Contracts.Repositories;
using LPP.Entities;
using LPP.Services.Contracts;

namespace LPP.Services
{
    public class SanctionService : BaseService<Sanction>, ISanctionService
    {
        public SanctionService(ISanctionRepository repository) : base(repository)
        {
        }
    }
}
