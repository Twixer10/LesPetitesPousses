using LPP.DTO;
using LPP.Entities;
using LPP.Services;
using LPP.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LPP.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public ProductController(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }

         [HttpPost]
         public async Task<IActionResult> Post(ProductDto productDto)
         {
            /// init le produit
             var seller = await _userService.GetByIdAsync(productDto.SellerId);
             if (seller is null)
             {
                return NotFound();
             }
            var product = productDto.ToProduct();
            product.Seller = seller;

            await _productService.AddAsync(product);
            return Ok(productDto);
         }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();
                        
            if (products is null)
            {
                return NotFound();
            }else
            {
                var productsDto = products.Select(x => new ProductDto(x)).ToList();
                return Ok(productsDto);
            }
            
        }
    }
}
