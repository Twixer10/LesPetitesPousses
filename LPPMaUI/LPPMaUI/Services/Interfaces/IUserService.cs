using LPPMaUI.Models.DTOs;
using LPPMaUI.Models.Entities;

namespace LPPMaUI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<DataTransferResult<UserDTO>> Register(UserDTO register);
        public Task<DataTransferResult<UserDTO>> Login(UserDTO login);
        public Task<UserEntity> SaveItem(UserEntity item);
        public Task<IEnumerable<UserEntity>> GetItems();
        public Task<UserEntity> UpdateItem(UserEntity item);

    }
}
