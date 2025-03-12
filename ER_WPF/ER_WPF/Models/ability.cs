using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ER_WPF.Models
{
    public class ability
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? effect { get; set; }
        public string? short_effect { get; set; }
        public string? description { get; set; }
        public int? generation { get; set; }
    }
}