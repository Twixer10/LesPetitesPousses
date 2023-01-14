using LPP.DAL.Contracts.Repositories;
using LPP.Entities;

namespace LPP.DAL.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LppDbContext context) : base(context)
        {
        }
    }
}