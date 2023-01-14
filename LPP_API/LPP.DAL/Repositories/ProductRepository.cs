using LPP.DAL.Contracts.Repositories;
using LPP.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LPP.DAL.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(LppDbContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Context.Set<Product>().Include(p => p.Seller).ToListAsync();

        }
    }
}
