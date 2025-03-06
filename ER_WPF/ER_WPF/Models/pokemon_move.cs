using System.ComponentModel.DataAnnotations;

namespace ER_WPF.Models
{
    class pokemon_move
    {
        [Key]
        public int pokemon { get; set; }
        public int move { get; set; }
        public int level_learned_at { get; set; }
        public string learn_method { get; set; }
    }
}
