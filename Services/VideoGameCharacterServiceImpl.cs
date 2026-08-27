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
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role,
                }).FirstOrDefaultAsync();

            return result;
        }

        public Task<CharacterRespone> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            return Task.FromResult(true);
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            return Task.FromResult(true);
        }
    }
}
