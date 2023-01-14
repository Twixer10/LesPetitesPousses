using LPP.DAL.Contracts.Repositories;
using LPP.Entities;
using LPP.Services.Contracts;

namespace LPP.Services
{
    public class PostService : BaseService<Post>, IPostService
    {
        public PostService(IPostRepository repository) : base(repository)
        {
        }
    }
}
