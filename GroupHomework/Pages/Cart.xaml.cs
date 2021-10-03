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
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GroupHomework.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Cart : Page
    {
        CartService service;
        public Cart()
        {
            this.InitializeComponent();
           
        }
        private void cartData_Loaded(object sender, RoutedEventArgs e)
        {
            RenderCart();
        }
        //private List<CartItem> CallData()
        //{
        //    CartService card = new CartService();
        //    var list = card.GetCart();
        //    return list;
        //}
        private void ReduceQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            int qty = service.ItemCount(id);
            service.UpdateItem(id, qty - 1);
            RenderCart();
        }

        private void QuantityTextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c)) || args.NewText.Length == 0;

        }
        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int id = (int)((TextBox)sender).Tag;
            service.UpdateItem(id, Int32.Parse(((TextBox)sender).Text));
            RenderCart();
        }

        private void IncreaseQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            int qty = service.ItemCount(id);
            service.UpdateItem(id, qty + 1);
            RenderCart();
        }
        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            service.RemoveItem(id);
            RenderCart();
        }

        private void RenderCart()
        {
            service = new CartService();

            List<CartItem> cart = service.GetCart();
            cartData.Items.Clear();
            if (cart != null)
            {
                foreach (CartItem item in cart)
                {
                    cartData.Items.Add(item);
                }
            }

            TotalAmount.Text = service.GetTotalAmount().ToString();

            //var list = CallData();
            //cartData.ItemsSource = list;
            //TotalAmount.Text = service.GetTotalAmount().ToString();
        }
        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            OrderService orderService = new OrderService();
            _ = orderService.CreateOrder();
            service.ClearCart();
            RenderCart();
        }
       
    }
}
