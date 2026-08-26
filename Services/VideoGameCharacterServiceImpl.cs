using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterServiceImpl : IVideoGameCharacterService
    {
        private readonly List<Character> _characters;

        public VideoGameCharacterServiceImpl()
        {
            _characters = new List<Character>
            {
                new Character { Id = 1, Name = "Mario", Game = "Super Mario Bros", Role = "Protagonist" },
                new Character { Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Hero" },
                new Character { Id = 3, Name = "Sonic", Game = "Sonic the Hedgehog", Role = "Protagonist" },
                new Character { Id = 4, Name = "Master Chief", Game = "Halo", Role = "Spartan" },
                new Character { Id = 5, Name = "Lara Croft", Game = "Tomb Raiders", Role = "Archaeologist" }
            };
        }

        public async Task<List<Character>> GetAllCharactersAsync()
        =>await Task.FromResult(_characters.ToList());
       

        public Task<Character?> GetCharacterByIdAsync(int id)
        {
            var character = _characters.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(character!);
        }

        public Task<Character> AddCharacterAsync(Character character)
        {
            var nextId = _characters.Any() ? _characters.Max(c => c.Id) + 1 : 1;
            character.Id = nextId;
            _characters.Add(character);
            return Task.FromResult(character);
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            var existing = _characters.FirstOrDefault(c => c.Id == id);
            if (existing == null) return Task.FromResult(false);

            existing.Name = character.Name;
            existing.Game = character.Game;
            existing.Role = character.Role;

            return Task.FromResult(true);
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            var existing = _characters.FirstOrDefault(c => c.Id == id);
            if (existing == null) return Task.FromResult(false);

            _characters.Remove(existing);
            return Task.FromResult(true);
        }
    }
}
