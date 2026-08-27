using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Dtos;
using System.Collections.Generic;
using System.Linq;
using VideoGameCharacterApi.Services;

namespace VideoGameCharacterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharacterController(IVideoGameCharacterService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<CharacterRespone>>> GetCharacters()
        => Ok(await service.GetAllCharactersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterRespone>> GetCharacter(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);
            return character is null ? NotFound("Character with the given ID was not found.") : Ok(character); 
        }

        [HttpPost]
        public async Task<ActionResult<CharacterRespone>> AddCharacter(CreateCharacterResponse createCharacterResponse)
        {
            var createdCharacter = await service.AddCharacterAsync(createCharacterResponse);
            return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, createdCharacter);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharacter(int id , UpdateCharacterResponse updateCharacterResponse)
        {
            var updated = await service.UpdateCharacterAsync(id, updateCharacterResponse);
            return updated ? NoContent() : NotFound("Character with given Id not found.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var deleted = await service.DeleteCharacterAsync(id);
            return deleted ? NoContent() : NotFound("Character with given Id not found.");
        }
    }
}
