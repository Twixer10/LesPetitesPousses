using LPPMaUI.Models.DTOs;
using LPPMaUI.Models.Entities;
using LPPMaUI.Repositories.Interfaces;
using LPPMaUI.Services.Interfaces;
using Newtonsoft.Json;

namespace LPPMaUI.Services
{
    public class UserService : IUserService
    {
        private readonly IApiService _apiService;
        private readonly IRepository<UserEntity> _repository;

        public UserService(IApiService apiService, IRepository<UserEntity> repository)
        {
            _apiService = apiService;
            _repository = repository;
        }

        public async Task<DataTransferResult<UserDTO>> Register(UserDTO register)
        {
            try
            {
                var result = await _apiService.CallApiAsync<UserDTO>("user", HttpMethod.Post, false, JsonConvert.SerializeObject(register));
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<DataTransferResult<UserDTO>> Login(UserDTO login)
        {
            try
            {
                var result = await _apiService.CallApiAsync<UserDTO>("token", HttpMethod.Post, false, JsonConvert.SerializeObject(login));
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<UserEntity> SaveItem(UserEntity item)
        {
            return await _repository.SaveItem(item);
        }

        public async Task<IEnumerable<UserEntity>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<UserEntity> UpdateItem(UserEntity item)
        {
            return await _repository.UpdateItem(item);
        }
    }
}
