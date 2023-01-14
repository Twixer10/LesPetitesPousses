using LPP.DAL.Contracts.Repositories;
using LPP.Entities;

namespace LPP.DAL.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(LppDbContext context) : base(context)
        {
        }
    }
}
