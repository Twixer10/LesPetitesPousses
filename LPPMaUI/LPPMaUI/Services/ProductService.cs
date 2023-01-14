using LPPMaUI.Models.DTOs;
using LPPMaUI.Services.Interfaces;
using Newtonsoft.Json;

namespace LPPMaUI.Services
{
    public class ProductService : IProductService
    {
        private readonly IApiService _apiService;

        public ProductService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<ProductDTO>> GetAllAsync()
        {
            try
            {
                var result = await _apiService.CallApiAsync<List<ProductDTO>>("Product", HttpMethod.Get, true);
                return result.Result;
            }
            catch (Exception e)
            {
                var message = e.Message;
                return new List<ProductDTO>(); // retour d'une liste vide
            }
        }

        public async Task<ProductDTO> AddAsync(ProductDTO product, string filePath)
        {
            try
            {
                var result = await _apiService.CallApiAsync<ProductDTO>("product", HttpMethod.Post, true, JsonConvert.SerializeObject(product));

                var newProduct = result.Result;

                var picture = await _apiService.SendFileApiAsync<PictureDTO>($"picture/{newProduct.Id}", filePath);

                return newProduct;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}