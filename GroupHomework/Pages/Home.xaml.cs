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
            GV.Items.Add(new Homes()
            {
                Title1 = "Only",
                Price = "$10",
                Name = "Cheeseburger",
                Title2 = "With Onions and tamato and ketchup",
                Title3 = "Lorem ipsum doler sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco",
                Img = new BitmapImage(new Uri("https://media-cdn.tripadvisor.com/media/photo-s/11/4f/df/79/cheese-burger.jpg"))
            });
        }

        private void Button_Click_Order(object sender, RoutedEventArgs e)
        {

        }
    }
}
