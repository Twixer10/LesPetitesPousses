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
    public class ChatController : ControllerBase
    {
        private IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var chats = await _chatService.GetAllAsync();
            if (!chats.Any())
                return NotFound();
            return Ok(chats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var chat = await _chatService.GetByIdAsync(id);
            if (chat is null)
                return NotFound("Chat not found");
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Chat chat)
        {
            //TODO: Aucune vériifcation n'est faite sur les données reçues on sait pas si c'est stocké reelement ou pas AddAsync retourne un obj sur et on sais pas si c'est null ou pas.
            var result = await _chatService.AddAsync(chat);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Chat chat)
        {
            //TODO: Aucune vérification d'insertion n'ai faite
            var result = await _chatService.UpdateAsync(chat);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            //TODO: Idem, aucune vérification de suppression n'ai faite
            await _chatService.DeleteByIdAsync(id);
            return Ok();
        }

    }
}
