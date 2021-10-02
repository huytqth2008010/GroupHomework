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
using GroupHomework.Adapters;
using SQLitePCL;
using GroupHomework.Services;
using Windows.UI.Popups;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GroupHomework.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FoodPage : Page
    {
     
        public FoodPage()
        {
            this.InitializeComponent();
        }

        private Models.Food _food;
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Models.Food food = e.Parameter as Models.Food;
            _food = food;
            Price.Text = food.price.ToString() + "$";
            Name.Text = food.name;
            //Description.Text = food.description;
            ImageProduct.UriSource = new Uri(food.image);

        }

        private async void AddToCart(object sender, RoutedEventArgs e)
        {
            CartService cart = new CartService();
            CartItem item = new CartItem()
            {
                Id = _food.id,
                Name = _food.name,
                ImageProduct = _food.image,
                Price = _food.price,
                Qty = 1,
            };
            if(cart.AddToCart(item))
            {
                var dialog = new MessageDialog("Add to cart error !");
                await dialog.ShowAsync();
            }
            else
            {
                var dialog = new MessageDialog("Add to cart successfully !");
                await dialog.ShowAsync();
            }
           
            //var list = cart.GetCart();
            
        }
    }
}
