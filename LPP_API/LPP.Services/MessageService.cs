using LPP.DAL.Contracts.Repositories;
using LPP.Entities;
using LPP.Services.Contracts;

namespace LPP.Services
{
    public class MessageService : BaseService<Message>, IMessageService
    {
        public MessageService(IMessageRepository repository) : base(repository)
        {
        }
    }
}
