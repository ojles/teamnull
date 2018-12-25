using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Task3.Service;

namespace Task3.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        private MenuService menuService = new MenuService();
        private OrderService orderService = new OrderService();
        private Order order = new Order();
        private Menu menu;

        public MenuPage()
        {
            InitializeComponent();

            menu = menuService.Get();

            List<OrderItem> items = new List<OrderItem>();
            foreach (Meal meal in menu.Meals)
            {
                items.Add(new OrderItem(meal, 0));
            }
            order.OrderItems = items;

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
            
            if (orderItem.Amount!=0)
            {
                orderItem.Amount--;
            }
            order.OrderItemsChanged();
        }

        private void SubmitOrderClick(object sender, RoutedEventArgs e)
        {
            order.OrderItems.RemoveAll(x => x.Amount == 0);
            MenuPage menuPage = new MenuPage();

            order.Place();

            string messageBoxText = "Your Order - " + order.Name.Substring(6) + "\n\n";
            foreach (var i in order.OrderItems)
            {
                messageBoxText += string.Format("{0}. {1} {2} - ${3}/item\n", order.OrderItems.IndexOf(i)+1,
                    i.Meal.Name, i.Amount, i.Price);
            }
            //for(int i = 0; i < order.OrderItems.Count; i++)
            //{
            //    messageBoxText += string.Format("{0}. {1} {2} {3} \n", i, order.OrderItems..Meal.Name, i.Amount, i.Price);
            //}
            messageBoxText += "\nTotal - $" + order.Price;
            string caption = "Order";
            MessageBoxButton buttons = MessageBoxButton.OKCancel;
            //MessageBoxButton buttonCancel = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, buttons, icon);
            if(messageBoxResult == MessageBoxResult.OK)
            {
                orderService.Save(order);
            }
        }
    }
}
