using System.ComponentModel.DataAnnotations;

namespace ER_WPF.Models
{
    class pokemon_species
    {
        [Key]
        public int? id { get; set; }
        public int? base_happiness { get; set; }
        public int? capture_rate { get; set; }
        public int? gender_rate { get; set; }
        public int? hatch_counter { get; set; }
        public int? order { get; set; }
        public int? generation { get; set; }
        public int? national_pokedex_number { get; set; }
        public bool? is_baby { get; set; }
        public bool? is_legendary { get; set; }
        public bool? is_mythical { get; set; }
        public string? color { get; set; }
        public string? growth_rate { get; set; }
        public string? habitat { get; set; }
        public string? shape { get; set; }
        public string? genera { get; set; }
        public string? name { get; set; }
        public string? egg_group { get; set; }
        public string? varieties { get; set; }
        public string? description { get; set; }

    }
}
