using ER_WPF.Data;
using ER_WPF.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Swift;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ER_WPF.Query
{
    class SearchQueryEngine
    {
        public enum LegendaryStatuses
        {
            None, Legendary, Mythical
        }

        private string? _name, _type1, _type2, _knowsmove, _ability, _appearance_color, _appearance_shape;
        private int? _generation, _appearance_height_min, _appearance_height_max, _appearance_weight_min, _appearance_weight_max;
        private int? _stat_hp_min, _stat_attack_min, _stat_defense_min, _stat_spatt_min, _stat_spdef_min, _stat_speed_min;
        private int? _stat_hp_max, _stat_attack_max, _stat_defense_max, _stat_spatt_max, _stat_spdef_max, _stat_speed_max;
        private LegendaryStatuses? _legendarystatus;

        public string? Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    UpdateQuery();
                }
            }
        }
        public string? Type1
        {
            get => _type1;
            set
            {
                if (_type1 != value)
                {
                    _type1 = value;
                    UpdateQuery();
                }
            }
        }
        public string? Type2
        {
            get => _type2;
            set
            {
                if (_type2 != value)
                {
                    _type2 = value;
                    UpdateQuery();
                }
            }
        }
        public int? Generation
        {
            get => _generation;
            set
            {
                if (_generation != value)
                {
                    _generation = value;
                    UpdateQuery();
                }
            }
        }
        public string? KnowsMove
        {
            get => _knowsmove;
            set
            {
                if (_knowsmove != value)
                {
                    _knowsmove = value;
                    UpdateQuery();
                }
            }
        }
        public string? Ability
        {
            get => _ability;
            set
            {
                if (_ability != value)
                {
                    _ability = value;
                    UpdateQuery();
                }
            }
        }
        public LegendaryStatuses? LegendaryStatus
        {
            get => _legendarystatus;
            set
            {
                if (_legendarystatus != value)
                {
                    _legendarystatus = value;
                    UpdateQuery();
                }
            }
        }
        public string? Appearance_Color
        {
            get => _appearance_color;
            set
            {
                if (_appearance_color != value)
                {
                    _appearance_color = value;
                    UpdateQuery();
                }
            }
        }
        public string? Appearance_Shape
        {
            get => _appearance_shape;
            set
            {
                if (_appearance_shape != value)
                {
                    _appearance_shape = value;
                    UpdateQuery();
                }
            }
        }
        public int? Appearance_Height_Min
        {
            get => _appearance_height_min;
            set
            {
                if (_appearance_height_min != value)
                {
                    _appearance_height_min = value;
                    UpdateQuery();
                }
            }
        }
        public int? Appearance_Height_Max
        {
            get => _appearance_height_max;
            set
            {
                if (_appearance_height_max != value)
                {
                    _appearance_height_max = value;
                    UpdateQuery();
                }
            }
        }
        public int? Appearance_Weight_Min
        {
            get => _appearance_weight_min;
            set
            {
                if (_appearance_weight_min != value)
                {
                    _appearance_weight_min = value;
                    UpdateQuery();
                }
            }
        }
        public int? Appearance_Weight_Max
        {
            get => _appearance_weight_max;
            set
            {
                if (_appearance_weight_max != value)
                {
                    _appearance_weight_max = value;
                    UpdateQuery();
                }
            }
        }
        public int? Stat_HP_Min
        {
            get => _stat_hp_min;
            set
            {
                if (_stat_hp_min != value)
                {
                    _stat_hp_min = value;
                    UpdateQuery();
                }
            }
        }
        public int? Stat_HP_Max
        {
            get => _stat_hp_max;
            set
            {
                if (_stat_hp_max != value)
                {
                    _stat_hp_max = value;
                    UpdateQuery();
                }
            }
        }
        public int? Stat_Attack_Min
        {
            get => _stat_attack_min;
            set
            {
                if (_stat_attack_min != value)
                {
                    _stat_attack_min = value;
                    UpdateQuery();
                }
            }
        }
        public int? Stat_Attack_Max
        {
            get => _stat_attack_max;
            set
            {
                if (_stat_attack_max != value)
                {
                    _stat_attack_max = value;
                    UpdateQuery();
                }
            }
        }
        public int? Stat_Defense_Min
        {
            get => _stat_defense_min;
            set
            {
                if (_stat_defense_min != value)
                {
                    _stat_defense_min = value;
                    UpdateQuery();
                }
            }
        }
        public int? Stat_Defense_Max
        {
            get => _stat_defense_max;
            set
            {
                if (_stat_defense_max != value)
                {
                    _stat_defense_max = value;
                    UpdateQuery();
                }
            }
        }
        public int? Stat_SpAtt_Min
        {
            get => _stat_spatt_min;
            set
            {
                if (_stat_spatt_min != value)
                {
                    _stat_spatt_min = value;
                    UpdateQuery();
                }
            }
        }
        public int? Stat_SpAtt_Max
        {
            get => _stat_spatt_max;
            set
            {
                if (_stat_spatt_max != value)
                {
                    _stat_spatt_max = value;
                    UpdateQuery();
                }
            }
        }
        public int? Stat_SpDef_Min
        {
            get => _stat_spdef_min;
            set
            {
                if (_stat_spdef_min != value)
                {
                    _stat_spdef_min = value;
                    UpdateQuery();
                }
            }
        }
        public int? Stat_SpDef_Max
        {
            get => _stat_spdef_max;
            set
            {
                if (_stat_spdef_max != value)
                {
                    _stat_spdef_max = value;
                    UpdateQuery();
                }
            }
        }
        public int? Stat_Speed_Min
        {
            get => _stat_speed_min;
            set
            {
                if (_stat_speed_min != value)
                {
                    _stat_speed_min = value;
                    UpdateQuery();
                }
            }
        }
        public int? Stat_Speed_Max
        {
            get => _stat_speed_max;
            set
            {
                if (_stat_speed_max != value)
                {
                    _stat_speed_max = value;
                    UpdateQuery();
                }
            }
        }

        private PokemonDataContext _context;
        private List<Models.pokemon> pokemonResults;

        SearchQueryEngine(PokemonDataContext _context)
        {
            this._context = _context;
            this.pokemonResults = new List<Models.pokemon>();
            this.UpdateQuery();
        }

        private void UpdateQuery()
        {
            IQueryable<Models.pokemon> pokemonQuery = this._context.pokemon;

            //Ability
            if (this.Ability != null && this.Ability.Length > 0)
            {
                pokemonQuery = pokemonQuery.Where(p =>
                    _context.ability
                    .Where(a => a.name == this.Ability)
                    .Any(a => a.id == p.primary_ability || a.id == p.secondary_ability || a.id == p.hidden_ability)
                );
            }

            //Move
            if (this.KnowsMove != null && this.KnowsMove.Length > 0)
            {
                pokemonQuery = pokemonQuery.Where(p => _context.pokemon_move
                    .Any(pm => pm.pokemon == p.id &&
                         _context.move
                         .Where(m => m.name == this.KnowsMove)
                         .Any(m => m.id == pm.move)
                    )
                );
            }

            //Type
            bool type1exists = this.Type1 != null && this.Type1.Length > 0;
            bool type2exists = this.Type2 != null && this.Type2.Length > 0;
            if (type1exists && type2exists && this.Type1 != this.Type2)
            {
                pokemonQuery = pokemonQuery.Where(p => (p.primary_type == this.Type1 && p.secondary_type == this.Type2 || p.secondary_type == this.Type1 && p.primary_type == this.Type2);
            }
            else if (this.Type1 != null && this.Type1.Length > 0)
            {
                pokemonQuery = pokemonQuery.Where(p => p.primary_type == this.Type1 || p.secondary_type == this.Type1);
            }
            else if (this.Type2 != null && this.Type2.Length > 0)
            {
                pokemonQuery = pokemonQuery.Where(p => p.primary_type == this.Type2 || p.secondary_type == this.Type2);
            }

            //Generation
            if (this.Generation != null)
            {
                pokemonQuery = pokemonQuery.Where(p =>
                    _context.pokemon_species
                    .Where(ps => ps.id == p.species)
                    .Any(ps => ps.generation == this.Generation)
                );
            }

            //Legendary Status
            if (this.LegendaryStatus != null) {
                bool isLegendary = this.LegendaryStatus == LegendaryStatuses.Legendary;
                bool isMythical = this.LegendaryStatus == LegendaryStatuses.Mythical;
                pokemonQuery = pokemonQuery.Where(p =>
                    _context.pokemon_species
                    .Where(ps => ps.id == p.species)
                    .Any(ps => ps.is_legendary == isLegendary && ps.is_mythical == isMythical)
                );
            }

            //Apearance - Color
            if (this.Appearance_Color != null && this.Appearance_Color.Length > 0)
            {
                pokemonQuery = pokemonQuery.Where(p =>
                    _context.pokemon_species
                    .Where(ps => ps.id == p.species)
                    .Any(ps => ps.color == this.Appearance_Color)
                );
            }

            //Apearance - Shape
            if (this.Appearance_Shape != null && this.Appearance_Shape.Length > 0)
            {
                pokemonQuery = pokemonQuery.Where(p =>
                    _context.pokemon_species
                    .Where(ps => ps.id == p.species)
                    .Any(ps => ps.shape == this.Appearance_Shape)
                );
            }

            //Apearance - Height
            if (this.Appearance_Height_Min != null) pokemonQuery = pokemonQuery.Where(p => p.height >= this.Appearance_Height_Min);
            if (this.Appearance_Height_Min != null) pokemonQuery = pokemonQuery.Where(p => p.height <= this.Appearance_Height_Max);

            //Apearance - Weight
            if (this.Appearance_Height_Min != null) pokemonQuery = pokemonQuery.Where(p => p.weight >= this.Appearance_Weight_Min);
            if (this.Appearance_Height_Min != null) pokemonQuery = pokemonQuery.Where(p => p.weight <= this.Appearance_Weight_Max);

            //Apearance - HP
            if (this.Stat_HP_Min != null) pokemonQuery = pokemonQuery.Where(p => p.hp >= this.Stat_HP_Min);
            if (this.Stat_HP_Min != null) pokemonQuery = pokemonQuery.Where(p => p.hp <= this.Stat_HP_Min);

            //Apearance - Attack
            if (this.Stat_Attack_Min != null) pokemonQuery = pokemonQuery.Where(p => p.hp >= this.Stat_Attack_Min);
            if (this.Stat_Attack_Max != null) pokemonQuery = pokemonQuery.Where(p => p.hp <= this.Stat_Attack_Max);

            //Apearance - Defense
            if (this.Stat_Defense_Min != null) pokemonQuery = pokemonQuery.Where(p => p.hp >= this.Stat_Defense_Min);
            if (this.Stat_Defense_Max != null) pokemonQuery = pokemonQuery.Where(p => p.hp <= this.Stat_Defense_Max);

            //Apearance - Special Attack
            if (this.Stat_SpAtt_Min != null) pokemonQuery = pokemonQuery.Where(p => p.hp >= this.Stat_SpAtt_Min);
            if (this.Stat_SpAtt_Max != null) pokemonQuery = pokemonQuery.Where(p => p.hp <= this.Stat_SpAtt_Max);

            //Apearance - Special Defense
            if (this.Stat_SpDef_Min != null) pokemonQuery = pokemonQuery.Where(p => p.hp >= this.Stat_SpDef_Min);
            if (this.Stat_SpDef_Max != null) pokemonQuery = pokemonQuery.Where(p => p.hp <= this.Stat_SpDef_Max);

            //Apearance - Speed
            if (this.Stat_Speed_Min != null) pokemonQuery = pokemonQuery.Where(p => p.hp >= this.Stat_Speed_Min);
            if (this.Stat_Speed_Max != null) pokemonQuery = pokemonQuery.Where(p => p.hp <= this.Stat_Speed_Max);

            this.pokemonResults = pokemonQuery.ToList();
        }
    }
}
