using System.Collections.Generic;
using System.Windows.Controls;

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

            OrderItem oi = new OrderItem(Meal.Create("Coffe", 15, "/Assets/cafe.png"), 10);
            OrderItem oi2 = new OrderItem(Meal.Create("Tea", 5, "/Assets/tea.png"), 10);


            List<OrderItem> menu = new List<OrderItem>
            {
                oi,
                oi2
            };
            Orders.ItemsSource = menu;
        }
    }
}
