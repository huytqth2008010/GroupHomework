using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace GroupHomework.Models
{
    public class RootHome
    {
        public string message { get; set; }
        public List<Food> data { get; set; }
    }
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
    }

    public class Categories  // Data transfer object
    {
        public string message { get; set; }
        public List<Category> data { get; set; }
    }

    public class Food
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int price { get; set; }

        public BitmapImage Img
        {
            get => new BitmapImage(new Uri(image));
        }
    }

    public class CategoryData
    {
        public Category category { get; set; }
        public List<Food> foods { get; set; }
    }

    public class CategoryDetail
    {
        public string message { get; set; }
        public CategoryData data { get; set; }
    }
}
