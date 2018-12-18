using System.Collections.Generic;
using System.Windows.Controls;
using System;

namespace Task3.Pages
{
    /// <summary>
    /// Interaction logic for RecepitPage.xaml
    /// </summary>
    public partial class ReceiptPage : Page
    {
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
            List<Order> list_orders = new List<Order>
            {
                order1,
                order2
            };
            Orders.ItemsSource = list_orders;
        }
    }
}
