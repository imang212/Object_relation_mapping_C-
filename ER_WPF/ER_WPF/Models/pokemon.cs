using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ER_WPF.Models
{
    public class pokemon
    {
        [Key]
        public int? id { get; set; }
        public int? base_experience { get; set; }
        public int? height { get; set; }
        public int? weight { get; set; }
        public int? order { get; set; }
        public int? primary_ability { get; set; }
        public int? secondary_ability { get; set; }
        public int? hidden_ability { get; set; }
        public int? species { get; set; }
        public int? hp { get; set; }
        public int? hp_effort { get; set; }
        public int? attack { get; set; }
        public int? attack_effort { get; set; }
        public int? defense { get; set; }
        public int? defense_effort { get; set; }
        public int? special_attack { get; set; }
        public int? special_attack_effort { get; set; }
        public int? special_defense { get; set; }
        public int? special_defense_effort { get; set; }
        public int? speed { get; set; }
        public int? speed_effort { get; set; }
        public string? sprite_front_default { get; set; }
        public string? sprite_front_female { get; set; }
        public string? sprite_front_shiny_female { get; set; }
        public string? sprite_front_shiny { get; set; }
        public string? sprite_back_default { get; set; }
        public string? sprite_back_female { get; set; }
        public string? sprite_back_shiny_female { get; set; }
        public string? sprite_back_shiny { get; set; }
        public string? cry { get; set; }
        public string? cry_legacy { get; set; }
        public string? name { get; set; }
        public string? primary_type { get; set; }
        public string? secondary_type { get; set; }
    }
}