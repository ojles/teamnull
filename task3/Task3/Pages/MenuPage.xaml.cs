using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Task3.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        private Order order = new Order();
        private Menu menu = (Menu)Application.Current.FindResource("SushiMenu");

        public MenuPage()
        {
            InitializeComponent();

            List<OrderItem> items = new List<OrderItem>();
            foreach (Meal meal in menu.Meals)
            {
                items.Add(new OrderItem(meal, 0));
            }
            order.ListOfOrders = items;

            Menu.ItemsSource = items;
            DataContext = order;

            // group meals by group name
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Menu.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Meal.Group");
            view.GroupDescriptions.Add(groupDescription);
        }

        private void PlusButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            OrderItem orderItem = button.DataContext as OrderItem;
            orderItem.Amount++;
            order.OrderItemsChanged();
        }

        private void MinusButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            OrderItem orderItem = button.DataContext as OrderItem;
            orderItem.Amount--;
            order.OrderItemsChanged();
        }

        private void SubmitOrderClick(object sender, RoutedEventArgs e)
        {
            // TODO: implement submit
            // use OrderService to do that
        }
    }
}
