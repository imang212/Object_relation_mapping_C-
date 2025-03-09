using ER_WPF.Data;
using ER_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ER_WPF.Query
{
    class PokemonFullDetails
    {
        private Models.pokemon pokemon;
        private List<Models.move> moves;
        private Models.pokemon_species species;
        private EvolutionTreeNode evolutionTree;
        private List<Models.ability> abilities;
        private string spriteUrl;
        private BitmapImage sprite;

        Models.pokemon Pokemon { get => this.pokemon; }
        public List<Models.move> Moves { get => this.moves; }
        public Models.pokemon_species Species { get => this.species; }
        public EvolutionTreeNode EvolutionTree { get => this.evolutionTree; }
        public List<Models.ability> Abilities { get => this.abilities; }
        public BitmapImage Sprite { get => sprite; }

        private PokemonDataContext _context;
        private PokemonFullDetails(PokemonDataContext _context) {
            this._context = _context;
        }

        void Update(int id)
        {
            this.pokemon = this._context.pokemon.FirstOrDefault(p => p.id <= id);
            if (this.pokemon == null)
            {
                this.moves = null;
                this.species = null;
                this.evolutionTree = null;
                this.abilities = null;
                return;
            }

            this.moves = this._context.move.Where(m => _context.pokemon_move.Any(pm => pm.pokemon == id)).ToList();
            this.species = this._context.pokemon_species.FirstOrDefault(s => s.id == this.Pokemon.species);
            this.evolutionTree = EvolutionTreeNode.Create(this._context, this.Pokemon);
            this.abilities = this._context.ability.Where(
                a => a.id == this.Pokemon.primary_ability ||
                a.id == this.Pokemon.secondary_ability ||
                a.id == this.Pokemon.hidden_ability
            ).ToList();

            this.spriteUrl = spriteUrl;
            this.sprite = loadImage(this.spriteUrl);
        }

        private BitmapImage loadImage(string url)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(url);
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();

            return bitmapImage;
        }

        public class EvolutionTreeNode
        {
            public readonly List<EvolutionTreeNode> children;
            public readonly Models.pokemon pokemon;
            public readonly Models.evolution_chain evolutionChain;

            private EvolutionTreeNode(Models.pokemon pokemon, Models.evolution_chain evolutionChain) {
                children = new List<EvolutionTreeNode>();
                pokemon = pokemon;
                this.evolutionChain = evolutionChain;
            }

            public static EvolutionTreeNode Create(PokemonDataContext _context, Models.pokemon pkmn)
            {
                if (pkmn == null) return null;
                EvolutionTreeNode node = new EvolutionTreeNode(pkmn, null);
                List<Models.pokemon> pokemon = _context.pokemon.Where(p =>
                    _context.evolution_chain.Where(ec => ec.from == pkmn.id).Any(ec => ec.to == p.id)
                ).ToList();
                foreach (Models.pokemon p in pokemon)
                {
                    node.children.Add(EvolutionTreeNode.Create(_context, p));
                }
                return node;
            }
        }
    }
}
