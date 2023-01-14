using LPP.DAL.Contracts.Repositories;
using LPP.Entities;

namespace LPP.DAL.Repositories
{
    public class HashtagRepository : BaseRepository<Hashtag>, IHashtagRepository
    {
        public HashtagRepository(LppDbContext context) : base(context)
        {
        }
    }
}
