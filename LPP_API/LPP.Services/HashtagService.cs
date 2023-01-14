using LPP.DAL.Contracts.Repositories;
using LPP.Entities;
using LPP.Services.Contracts;

namespace LPP.Services
{
    public class HashtagService : BaseService<Hashtag>, IHashtagService
    {
        public HashtagService(IHashtagRepository repository) : base(repository)
        {
        }
    }
}
