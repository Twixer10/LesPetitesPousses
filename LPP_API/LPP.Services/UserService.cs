using LPP.API.Exception;
using LPP.DAL.Contracts.Repositories;
using LPP.DTO;
using LPP.Entities;
using LPP.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace LPP.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository repository) : base(repository)
        {
            _userRepository = (IUserRepository)repository;
        }
        
        public async Task<User> Register(UserDto user)
        {
            // Verify if email exist
            var userExist = await _userRepository.GetByEmailAsync(user.Email);
            if (userExist != null)
            {
                throw new EmailAlreadyUseException("Cette adresse email est déjà utilisée");
            }
            var pseudoExist = await _userRepository.GetByPseudoAsync(user.Pseudo);
            if (pseudoExist != null)
            {
                throw new PseudoAlreadyUseException("Ce pseudo est déjà utilisé");
            }
            var hasher = new PasswordHasher<User>();

            var userToCreate = new User
            {
                Email = user.Email,
                Pseudo = user.Pseudo,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
            };
            var password = hasher.HashPassword(userToCreate, user.Password!);
            userToCreate.Password = password;
            return await _userRepository.AddAsync(userToCreate); 
        }

        public async Task<User?> GetUserByIdentifier(string identifier, string password)
        {
            User? user = null;
            if (identifier.Contains('@'))
            {
                user = (await _userRepository.GetByEmailAsync(identifier))!;
            }
            else
            {
                user = (await _userRepository.GetByPseudoAsync(identifier))!;
            }

            if (user == null)
            {
                return null;
            }
            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.Password, password);
            return result == PasswordVerificationResult.Failed ? null : user;
        }
    }
}
