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
using GroupHomework.Models;
using Windows.UI.Xaml.Media.Imaging;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GroupHomework.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
            //GV.Items.Add(new Models.Home()
            //{
            //    Title1 = "Only",
            //    Price = "$10",
            //    Name = "Cheeseburger",
            //    Title2 = "With Onions and tamato and ketchup",
            //    Title3 = "Lorem ipsum doler sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco",
            //    Img = new BitmapImage(new Uri("https://media-cdn.tripadvisor.com/media/photo-s/11/4f/df/79/cheese-burger.jpg"))
            //});
        }
        private void Gv_Loaded(object sender, RoutedEventArgs e)
        {

            RenderData();

        }

        private async void RenderData()
        {
            Services.MenuService service = new Services.MenuService();
            var categoryDetail = await service.GetHome();
            if (categoryDetail != null)
            {
                GV.ItemsSource = categoryDetail.data;
            }
        }
        private void GridViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Food food = GV.SelectedItem as Food;
            MainPage._mainFrame.Navigate(typeof(FoodPage), food);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
