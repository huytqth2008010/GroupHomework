using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace GroupHomework.Models
{
    public class CartItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public int price { get; set; }
        public int qty { get; set; }

        public BitmapImage bImage
        {
            get => new BitmapImage(new Uri(image));
        }
    }
}
