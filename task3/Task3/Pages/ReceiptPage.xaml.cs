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

            Order order1 = new Order(menu, "My Order 1", DateTime.Now, "In Progress");
            Order order2 = new Order(menu, "My Order 2", DateTime.Now, "Delivered");
            List<Order> list_orders = new List<Order>
            {
                order1,
                order2
                };
            Orders.ItemsSource = list_orders;
        }
    }
}
