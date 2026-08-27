using VideoGameCharacterApi.Dtos;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<CharacterRespone>> GetAllCharactersAsync();
        Task<CharacterRespone?> GetCharacterByIdAsync(int id);
        Task<CharacterRespone> AddCharacterAsync(CreateCharacterResponse character);
        Task<bool> UpdateCharacterAsync(int id,UpdateCharacterResponse character);
        Task<bool> DeleteCharacterAsync(int id);
    }
}
