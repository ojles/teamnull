using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Windows.Input;
using System.Windows;
using Task3.Service;
using System.Collections.ObjectModel;

namespace Task3.Pages
{
    /// <summary>
    /// Interaction logic for RecepitPage.xaml
    /// </summary>
    public partial class ReceiptPage : Page
    {
        private OrderService orderService = new OrderService();
        private ObservableCollection<Order> orders;

        public ReceiptPage()
        {
            InitializeComponent();
            orders = new ObservableCollection<Order>(orderService.GetAll());
            Orders.ItemsSource = orders;
        }

        public override string ToString()
        {
            string result = "";
            foreach(var i in orders)
            {
                result += i.ToString();
            }
            return result;
        }

        private void createOrderInfo(Order order)
        {
            string messageBoxText = "Your Order - " + order.Name.Substring(6) + "\n\n";
            foreach (var i in order.OrderItems)
            {
                messageBoxText += string.Format("{0}. {1} {2} - ${3}\n", order.OrderItems.IndexOf(i) + 1,
                    i.Meal.Name, i.Amount, i.Price);
            }
            messageBoxText += "\nTotal - $" + order.Price;
            string caption = "Order";
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(messageBoxText, caption, buttons, icon);
        }

        private void OrderDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(Orders.SelectedItem != null)
            {
                createOrderInfo((Order)Orders.SelectedItem);                
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var order = button.DataContext as Order;

                ((ObservableCollection<Order>)Orders.ItemsSource).Remove(order);
                orderService.Delete(order.Name);               
            }
            else
            {
                return;
            }
        }
    }
}
