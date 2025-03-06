using Microsoft.EntityFrameworkCore;
using ER_WPF.Models;

namespace ER_WPF.Data
{
    class PokemonDataContext : DbContext
    {
        public DbSet<ability> Ability { get; set; }
        public DbSet<move> Move { get; set; }
        public DbSet<pokemon> Pokemon { get; set; }
        public DbSet<pokemon_species> Pokemon_species { get; set; }
        public DbSet<pokemon_move> Pokemon_move { get; set; }
        public DbSet<evolution_chain> Evolution_chain { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=");
        }
    }
}
