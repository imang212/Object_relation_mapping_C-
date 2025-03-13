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

        private PokemonDataContext _context;
        private List<Models.pokemon> pokemonResults;
        private List<PokemonBriefDetails> pokemonBriefDetails;
        private MainWindow window;

        public SearchQueryEngine(MainWindow window, PokemonDataContext _context)
        {
            this.window = window;
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
            this.pokemonResults = new List<Models.pokemon>();
            this.pokemonBriefDetails = new List<PokemonBriefDetails>();
            this.Init();
            this.window.UpdateGrid();
        }
        public List<Models.pokemon> Results
        {
            get
            {
                return this.pokemonResults;
            }
        }
        public List<PokemonBriefDetails> DisplayResults
        {
            get
            {
                return this.pokemonBriefDetails;
            }
        }
        public List<Models.pokemon> GetAllPokemons()
        {
            return _context.pokemon.ToList();
        }
        
        public string? Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
                }
            }
        }


        public void Init()
        {
            UpdateQuery();
            this.pokemonBriefDetails.Clear();
            foreach (Models.pokemon p in this.Results)
            {
                this.pokemonBriefDetails.Add(new PokemonBriefDetails(p));
            }
        }
        public void Update()
        {
            UpdateQuery();
            this.pokemonBriefDetails.Clear();
            foreach (Models.pokemon p in this.Results)
            {
                this.pokemonBriefDetails.Add(new PokemonBriefDetails(p));
            }
            this.window.UpdateGrid();
        }
        public void UpdateQuery()
        {
            //TODO
        }
    }
}
