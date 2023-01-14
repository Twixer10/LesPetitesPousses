using LPP.DAL.Contracts.Repositories;
using LPP.Entities;

namespace LPP.DAL.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(LppDbContext context) : base(context)
        {
        }
    }
}
