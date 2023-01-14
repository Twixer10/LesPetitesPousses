using LPP.DAL.Contracts.Repositories;
using LPP.Entities;
using LPP.Services.Contracts;

namespace LPP.Services
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(ICommentRepository repository) : base(repository)
        {
        }
    }
}
