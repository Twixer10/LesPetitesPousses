using LPP.DAL.Contracts.Repositories;
using LPP.Entities;
using LPP.Services.Contracts;

namespace LPP.Services
{
    public class ChatService : BaseService<Chat>, IChatService
    {
        public ChatService(IChatRepository repository) : base(repository)
        {
        }
    }
}
