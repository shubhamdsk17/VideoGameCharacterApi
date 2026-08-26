using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) :DbContext(options)
    {
        public DbSet<Character> Characters => Set<Character>();
    }
}
