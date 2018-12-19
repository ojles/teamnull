using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Windows.Input;
using System.Windows;

namespace Task3.Pages
{
    /// <summary>
    /// Interaction logic for RecepitPage.xaml
    /// </summary>
    public partial class ReceiptPage : Page
    {
        List<Order> list_orders;
        public ReceiptPage()
        {
            InitializeComponent();

            OrderItem oi = new OrderItem(Meal.Create("Coffee", 15, "/Assets/cafe.png"), 10);
            OrderItem oi2 = new OrderItem(Meal.Create("Tea", 5, "/Assets/tea.png"), 10);


            List<OrderItem> menu = new List<OrderItem>
            {
                oi,
                oi2
            };

            Order order1 = Order.Place(menu, "My Order 1");
            Order order2 = Order.Place(menu, "My Order 2");
            list_orders = new List<Order>
            {
                order1,
                order2              
            };
            
            Orders.ItemsSource = list_orders;
        }

        public override string ToString()
        {
            string result = "";
            foreach(var i in list_orders)
            {
                result += i.ToString();
            }
            return result;
        }
        private void OrderDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            ReceiptPage r = new ReceiptPage();
            string messageBoxText = r.ToString();
            string caption = "Orders";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(messageBoxText, caption, button, icon);

        }
    }
}
