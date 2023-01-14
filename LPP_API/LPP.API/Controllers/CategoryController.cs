using LPP.Entities;
using LPP.Services;
using LPP.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            if (!categories.Any())
                return NotFound();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            //TODO: On peut pas savoir si la méthode renvoie null ou si la catégorie n'existe pas
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(category);

        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Category category)
        {
            //TODO: On peut pas savoir si la méthode renvoie null ou si la catégorie existe déjà
            var newCategory = await _categoryService.AddAsync(category);
            return Ok(newCategory);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Category category)
        {
            //TODO: On peut pas savoir si la méthode renvoie null ou si la catégorie n'existe pas
            var updatedCategory = await _categoryService.UpdateAsync(category);
            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            //TODO: La méthode renvoie void on peut pas savoir si la catégorie n'existe pas, si elle a était delete ou pas
            await _categoryService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
