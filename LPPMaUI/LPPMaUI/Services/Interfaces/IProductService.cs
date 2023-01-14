using LPPMaUI.Models.DTOs;

namespace LPPMaUI.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ProductDTO> AddAsync(ProductDTO product, string filePath);
        public Task<List<ProductDTO>> GetAllAsync();
    }
}
