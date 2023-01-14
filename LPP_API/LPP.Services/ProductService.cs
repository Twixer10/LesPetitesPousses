using LPP.DAL.Contracts.Repositories;
using LPP.DTO;
using LPP.Entities;
using LPP.Services.Contracts;

namespace LPP.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IProductRepository repository) : base(repository)
        {
        }
    }
}
