using LPP.DAL.Contracts.Repositories;
using LPP.Entities;
using Microsoft.EntityFrameworkCore;

namespace LPP.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly LppDbContext _context;
        public UserRepository(LppDbContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<User?> GetByPseudoAsync(string pseudo)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Pseudo == pseudo);
        }
    }
}
