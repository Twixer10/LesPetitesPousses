using LPP.DAL.Contracts.Repositories;
using LPP.Entities;
using LPP.Services.Contracts;

namespace LPP.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository) : base(repository)
        {
        }
    }
}