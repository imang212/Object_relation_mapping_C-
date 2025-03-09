using ER_WPF.Data;
using ER_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Swift;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ER_WPF.Query
{
    class PokemonBriefDetails
    {
        private Models.pokemon pokemon;
        private string spriteUrl;
        private BitmapImage sprite;
        private string type1;
        private string type2;

        public Models.pokemon Pokemon { get => pokemon; }
        public BitmapImage Sprite { get => sprite; }
        public string Type1 { get => type1; }
        public string Type2 { get => type2; }

        private PokemonDataContext _context;

        public PokemonBriefDetails(PokemonDataContext _context, Models.pokemon pokemon)
        { 
            this._context = _context;
            this.pokemon = pokemon;
            this.type1 = pokemon.primary_type;
            this.type2 = pokemon.secondary_type;
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
    }
}
