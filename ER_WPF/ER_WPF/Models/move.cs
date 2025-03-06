using System.ComponentModel.DataAnnotations;

namespace ER_WPF.Models
{
    class move
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int accuracy { get; set; }
        public string damage_class { get; set; }
        public int effect_chance { get; set; }
        public int generation { get; set; }
        public string ailment { get; set; }
        public string ailment_chance { get; set; }
        public int crit_rate { get; set; }
        public int drain { get; set; }
        public int flinch_chance { get; set; }
        public int healing { get; set; }
        public int max_hits { get; set; }
        public int min_turns { get; set; }
        public int stat_chance { get; set; }
        public int power { get; set; }
        public int pp { get; set; }
        public int priority { get; set; }
        public int target { get; set; }
        public int type { get; set; }
        public int description { get; set; }

    }
}
