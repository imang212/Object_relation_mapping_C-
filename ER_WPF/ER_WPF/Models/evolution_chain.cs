using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace ER_WPF.Models
{
    class evolution_chain
    {
        [Key]
        public int id { get; set; }
        [Column("\"from\"")]
        public int? from { get; set; }
        [Column("\"to\"")]
        public int? to { get; set; }
        public int? gender { get; set; }
        public int? min_beauty { get; set; }
        public int? min_happiness { get; set; }
        public int? min_level { get; set; }
        public string? trade_species { get; set; }
        public int? relative_physical_stats { get; set; }
        public string? item { get; set; }
        public string? held_item { get; set; }
        public string? known_move { get; set; }
        public string? known_move_type { get; set; }
        public string? trigger { get; set; }
        public string? party_species { get; set; }
        public string? party_type { get; set; }
        public string? time_of_day { get; set; }
        public bool? needs_overworld_rain { get; set; }
        public bool? turn_upside_down { get; set; }

    }
}
