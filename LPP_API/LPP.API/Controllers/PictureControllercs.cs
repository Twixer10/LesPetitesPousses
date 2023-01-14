using LPP.DTO;
using LPP.Entities;
using LPP.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LPP.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IPictureService _pictureService;

        public PictureController(IProductService productService, IUserService userService, IPictureService pictureService)
        {
            _productService = productService;
            _pictureService = pictureService;
        }

        [HttpPost("{itemId}")]
        public async Task<IActionResult> Post(Guid itemId, PicturesDto picturesDto)
        {
            var product = await _productService.GetByIdAsync(itemId!);

            if (product == null)
                return NotFound(
                    new {
                        message = "Le produit n'a pas été trouvé"
                    });

            if (picturesDto == null)
                return BadRequest(
                    new {
                        message = "PicturesDto : Body null"
                    });

            /// sauvergarder les images
            foreach (IFormFile p in picturesDto.Pictures!)
            {
                var pictureProduct = new PictureProduct()
                {
                    Item = product,
                    ItemId = product.Id
                };
                product.Pictures!.Append(pictureProduct);


                var filePath = _pictureService.CreateFilePath(pictureProduct.Id);
                pictureProduct.PictureURL = filePath;
                await _pictureService.SaveFileAsync(p, filePath);
            }

            return Ok(picturesDto);
        }
    }
}
