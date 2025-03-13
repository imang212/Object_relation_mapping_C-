using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ER_WPF.Query
{
    class ImageBuffer
    {
        static private readonly Dictionary<string, BitmapImage> images = new Dictionary<string, BitmapImage>();

        static public BitmapImage loadImage(string url)
        {
            if (url == null || url.Equals("")) return null;
            if (images.ContainsKey(url)) return images[url];

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(url);
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();

            return images[url] = bitmapImage;
        }
    }
}
