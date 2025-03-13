using ER_WPF.Data;
using ER_WPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.Swift;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ER_WPF.Query
{
    public class PokemonBriefDetails
    {
        static private Dictionary<string, System.Windows.Media.Color> fills = GetFillDictionary();
        static private Dictionary<string, System.Windows.Media.Color> borders = GetBorderDictionary();
        static private Dictionary<string, System.Windows.Media.Color> GetFillDictionary()
        {
            Dictionary<string, System.Windows.Media.Color> dict = new Dictionary<string, System.Windows.Media.Color>();
            dict.Add("NORMAL", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xA8, (byte)0xA7, (byte)0x7A));
            dict.Add("BUG", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xA6, (byte)0xB9, (byte)0x1A));
            dict.Add("DARK", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x70, (byte)0x57, (byte)0x46));
            dict.Add("DRAGON", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x6F, (byte)0x35, (byte)0xFC));
            dict.Add("ELECTRIC", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xF7, (byte)0xD0, (byte)0x2C));
            dict.Add("FAIRY", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xD6, (byte)0x85, (byte)0xAD));
            dict.Add("FIGHTING", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xC2, (byte)0x2E, (byte)0x28));
            dict.Add("FIRE", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xEE, (byte)0x81, (byte)0x30));
            dict.Add("FLYING", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xA9, (byte)0x8F, (byte)0xF3));
            dict.Add("GHOST", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x73, (byte)0x57, (byte)0x97));
            dict.Add("GRASS", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x7A, (byte)0xC7, (byte)0x4C));
            dict.Add("GROUND", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xE2, (byte)0xBF, (byte)0x65));
            dict.Add("ICE", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x96, (byte)0xD9, (byte)0xD6));
            dict.Add("POISON", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xA3, (byte)0x3E, (byte)0xA1));
            dict.Add("PSYCHIC", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xF9, (byte)0x55, (byte)0x87));
            dict.Add("ROCK", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xB6, (byte)0xA1, (byte)0x36));
            dict.Add("STEEL", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xB7, (byte)0xB7, (byte)0xCE));
            dict.Add("WATER", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x63, (byte)0x90, (byte)0xF0));
            dict.Add("", System.Windows.Media.Color.FromArgb((byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00));
            return dict;
        }
        static private Dictionary<string, System.Windows.Media.Color> GetBorderDictionary()
        {
            Dictionary<string, System.Windows.Media.Color> dict = new Dictionary<string, System.Windows.Media.Color>();
            dict.Add("NORMAL", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x00, (byte)0x00, (byte)0x00));
            dict.Add("BUG", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x00, (byte)0x00, (byte)0x00));
            dict.Add("DARK", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xFF, (byte)0xFF, (byte)0xFF));
            dict.Add("DRAGON", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xFF, (byte)0xFF, (byte)0xFF));
            dict.Add("ELECTRIC", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x00, (byte)0x00, (byte)0x00));
            dict.Add("FAIRY", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x00, (byte)0x00, (byte)0x00));
            dict.Add("FIGHTING", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x00, (byte)0x00, (byte)0x00));
            dict.Add("FIRE", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x00, (byte)0x00, (byte)0x00));
            dict.Add("FLYING", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x00, (byte)0x00, (byte)0x00));
            dict.Add("GHOST", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xFF, (byte)0xFF, (byte)0xFF));
            dict.Add("GRASS", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xFF, (byte)0xFF, (byte)0xFF));
            dict.Add("GROUND", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x00, (byte)0x00, (byte)0x00));
            dict.Add("ICE", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x00, (byte)0x00, (byte)0x00));
            dict.Add("POISON", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x00, (byte)0x00, (byte)0x00));
            dict.Add("PSYCHIC", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x00, (byte)0x00, (byte)0x00));
            dict.Add("ROCK", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x00, (byte)0x00, (byte)0x00));
            dict.Add("STEEL", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0x00, (byte)0x00, (byte)0x00));
            dict.Add("WATER", System.Windows.Media.Color.FromArgb((byte)0xFF, (byte)0xFF, (byte)0xFF, (byte)0xFF));
            dict.Add("", System.Windows.Media.Color.FromArgb((byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00));
            return dict;
        }

        private int id;
        private Models.pokemon pokemon;
        private string name;
        private string spriteUrl;
        private BitmapImage sprite;
        private string type1;
        private string type2;

        public BitmapImage Sprite { get => sprite; }
        public int ID { get => id; }
        public string Name { get => name; }
        public string Type1 { get => type1; }
        public string Type2 { get => type2; }
        public System.Windows.Media.Color Type1Fill { get => PokemonBriefDetails.fills[Type1]; }
        public System.Windows.Media.Color Type2Fill { get => PokemonBriefDetails.fills[Type2]; }
        public System.Windows.Media.Color Type1Border { get => PokemonBriefDetails.borders[Type1]; }
        public System.Windows.Media.Color Type2Border { get => PokemonBriefDetails.borders[Type2]; }


        public PokemonBriefDetails(Models.pokemon pokemon)
        {
            this.id = (int)pokemon.id;
            this.name = pokemon.name.Substring(0, 1).ToUpper() + pokemon.name.Substring(1);
            this.type1 = pokemon.primary_type == null ? "" : pokemon.primary_type.ToUpper();
            this.type2 = pokemon.secondary_type == null ? "" : pokemon.secondary_type.ToUpper();
            this.spriteUrl = pokemon.sprite_front_default == null ? "" : pokemon.sprite_front_default;
            this.sprite = ImageBuffer.loadImage(this.spriteUrl);
        }

        
    }
}
