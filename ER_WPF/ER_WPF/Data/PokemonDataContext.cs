using Microsoft.EntityFrameworkCore;
using ER_WPF.Models;

namespace ER_WPF.Data
{
    class PokemonDataContext : DbContext
    {
        public DbSet<model> Pokemons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True;");
        }
    }
}
