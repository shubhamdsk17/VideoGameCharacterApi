using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Dtos;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterServiceImpl(AppDBContext context) : IVideoGameCharacterService
    {
     
        public async Task<List<CharacterRespone>> GetAllCharactersAsync()
            => await context.Characters.Select(c => new CharacterRespone
                {
                    Id = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                }).ToListAsync();

        public async Task<CharacterRespone?> GetCharacterByIdAsync(int id)
        {
            var result = await context.Characters
                .Where(c => c.Id == id)
                .Select(c => new CharacterRespone
                {
                    Id   = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role,
                }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<CharacterRespone> AddCharacterAsync(CreateCharacterResponse character)
        {
            var newCharacter = new Character
            {
                Name = character.Name,
                Game = character.Game,
                Role = character.Role,
            };
            context.Characters.Add(newCharacter);
            await context.SaveChangesAsync();

            return new CharacterRespone
            {
                Id = newCharacter.Id,
                Name = newCharacter.Name,
                Game = newCharacter.Game,
                Role = newCharacter.Role,
            };
        }

        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterResponse character)
        {
            var existingCharacter = await context.Characters.FindAsync(id);
            if (existingCharacter is null) return false;

            existingCharacter.Name = character.Name;
            existingCharacter.Game = character.Game;
            existingCharacter.Role = character.Role;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var characterToDelete = await context.Characters.FindAsync(id);
            if (characterToDelete is null) return false;

            context.Characters.Remove(characterToDelete);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
