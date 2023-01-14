using LPP.DTO;
using LPP.Entities;

namespace LPP.Services.Contracts
{
    public interface IUserService : IHybridBaseService<User>
    {
        public Task<User> Register(UserDto user);
        public Task<User?> GetUserByIdentifier(string identifier, string password);
    }
}
