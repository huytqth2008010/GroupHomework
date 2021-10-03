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
using GroupHomework.Services;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GroupHomework.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AllOrdersPage : Page
    {
        OrderService orderService;
        public AllOrdersPage()
        {
            this.InitializeComponent();
        }

        private void OrderList_Loaded(object sender, RoutedEventArgs e)
        {
            RenderOrderList();
        }
        public void RenderOrderList()
        {
            orderService = new OrderService();
            List<OrderProduct> orderList = orderService.GetOrderList();
            OrderList.ItemsSource = orderList;
        }

        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            MainPage._mainFrame.Navigate(typeof(Pages.OrderDetail), id);
        }
    }
}
