using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using GroupHomework.Models;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GroupHomework.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Eat : Page
    {
        public Eat()
        {
            this.InitializeComponent();
            GV.Items.Add(new EatIns() { Name = "Buger", Title = "Bánh ngon Buger ngon nhất Việt Nam 1", Price = "10$", Img = new BitmapImage(new Uri("https://dscnnwjxnwl3f.cloudfront.net/media/catalog/product/cache/584039753b87a8d227764e04fc461e3e/h/a/hawaii_burger_1_2.jpg")) });
            GV.Items.Add(new EatIns() { Name = "Buger 2", Title = "Bánh ngon Buger ngon nhất Việt Nam 2", Price = "50$", Img = new BitmapImage(new Uri("https://dscnnwjxnwl3f.cloudfront.net/media/catalog/product/cache/584039753b87a8d227764e04fc461e3e/h/a/hawaii_burger_1_2.jpg")) });
            GV.Items.Add(new EatIns() { Name = "Buger 3", Title = "Bánh ngon Buger ngon nhất Việt Nam 3", Price = "100$", Img = new BitmapImage(new Uri("https://dscnnwjxnwl3f.cloudfront.net/media/catalog/product/cache/584039753b87a8d227764e04fc461e3e/h/a/hawaii_burger_1_2.jpg")) });
        }


        private async void SubscribeButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
