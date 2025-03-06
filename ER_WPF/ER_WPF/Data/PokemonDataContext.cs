using Microsoft.EntityFrameworkCore;
using ER_WPF.Models;

namespace ER_WPF.Data
{
    class PokemonDataContext : DbContext
    {
        public DbSet<ability> ability { get; set; }
        public DbSet<move> move { get; set; }
        public DbSet<pokemon> pokemon { get; set; }
        public DbSet<pokemon_species> pokemon_species { get; set; }
        public DbSet<pokemon_move> pokemon_move { get; set; }
        public DbSet<evolution_chain> evolution_chain { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=");
        }
    }
}
