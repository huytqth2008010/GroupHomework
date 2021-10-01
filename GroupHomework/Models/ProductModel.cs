using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
namespace GroupHomework.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string price { get; set; }

        public BitmapImage Img
        {
            get => new BitmapImage(new Uri(image));
        }
    }

    public class Products
    {
        public string message { get; set; }
        public List<Product> data { get; set; }
    }
}
