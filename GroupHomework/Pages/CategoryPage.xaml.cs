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
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GroupHomework.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoryPage : Page
    {
        public CategoryPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Category category = e.Parameter as Category;
            Title.Text = category.name;
            RenderFoods(category);
        }

        private async void RenderFoods(Category category)
        {
            Services.MenuService service = new Services.MenuService();
            var categoryDetail = await service.GetCategoryDetail(category.id.ToString());
            if (categoryDetail != null)
            {
                Products.ItemsSource = categoryDetail.data.foods;
            }
        }

        private void GridViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Food food = Products.SelectedItem as Food;
            MainPage._mainFrame.Navigate(typeof(FoodPage), food);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Food food = Products.SelectedItem as Food;
            MainPage._mainFrame.Navigate(typeof(FoodPage), food);
        }
    }
}
