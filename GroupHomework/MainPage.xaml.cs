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
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GroupHomework
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static Frame _mainFrame;
        public MainPage()
        {
            this.InitializeComponent();
            _mainFrame = MainFrame;
            MainFrame.Navigate(typeof(Pages.Cart));

        }
        private void HomePage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Pages.Home));
        }
        private void EatIn(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Pages.Cart));
        }

        private void FontIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SP.IsPaneOpen = !SP.IsPaneOpen;
        }

        private void Menu_Loaded(object sender, RoutedEventArgs e)
        {
            var item1 = new MenuItem() { Name = "Home", MenuPage = "home", Icon = "/Images/Button1.png" };
            var item2 = new MenuItem() { Name = "Cart", MenuPage = "cart", Icon = "/Images/Button2.png" };
            var item3 = new MenuItem() { Name = "Order", MenuPage = "order", Icon = "/Images/Button2.png" };
            // Gia su co 1 danh sach category
            // new MenuItem() { Name = "Ten cua category", MenuPage = "category", Icon = "\uE946" };
            Menu.Items.Add(item1);
            Menu.Items.Add(item2);
            Menu.Items.Add(item3);
            RenderCategoriesToMenu();
        }

        private void ListViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MenuItem selectedItem = (MenuItem)Menu.SelectedItem;
            switch (selectedItem.MenuPage)
            {
                case "home": MainFrame.Navigate(typeof(Pages.Home), selectedItem); break; // Page
                case "cart": MainFrame.Navigate(typeof(Pages.Cart)); break;
                case "order": MainFrame.Navigate(typeof(Pages.AllOrdersPage)); break;
                case "category": MainFrame.Navigate(typeof(Pages.CategoryPage), selectedItem.Category); break;
                    //case "category": MainFrame.Navigate(typeof(Pages.Category),category); break;
            }
        }
        public async void RenderCategoriesToMenu()
        {
            // dung Service de lay object Categories
            Services.MenuService service = new Services.MenuService();
            Models.Categories categories = await service.GetMenu();
            if (categories != null)
            {
                foreach (Models.Category c in categories.data)
                {
                    Menu.Items.Add(new MenuItem() { Name = c.name, MenuPage = "category", Icon = c.icon, Category = c });

                }
            }
        }
    }
}
