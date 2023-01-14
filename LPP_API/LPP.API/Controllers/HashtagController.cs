using LPP.Entities;
using LPP.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HashtagController : ControllerBase
    {
        private IHashtagService _hashtagService;

        public HashtagController(IHashtagService hashtagService)
        {
            _hashtagService = hashtagService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var hashtags = await _hashtagService.GetAllAsync();
            if (!hashtags.Any())
                return NotFound();
            return Ok(hashtags);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var hashtag = await _hashtagService.GetByIdAsync(id);
            if (hashtag is null)
                return NotFound("Hashtag not found");
            return Ok(hashtag);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Hashtag hashtag)
        {
            //TODO : Faire le check pour voir si le hashtag existe déjà ou pas et renvoyer une erreur si c'est le cas
            var newHashtag = await _hashtagService.AddAsync(hashtag);
            return Ok(newHashtag);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Hashtag hashtag)
        {
            //TODO: Faire le check pour voir si le hashtag existe ou pas et renvoyer une erreur si c'est le cas
            var updatedHashtag = await _hashtagService.UpdateAsync(hashtag);
            return Ok(updatedHashtag);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            // TODO: Ici la méthode renvoie rien du coup on sait pas si ça a marché ou pas
            await _hashtagService.DeleteByIdAsync(id);
            return Ok();
        }
        
    }
}
