using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Windows.Input;
using System.Windows;
using Task3.Service;
using System.Collections.ObjectModel;
using Task3.Domain;

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

        private void OrderDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            string messageBoxText = ToString();
            string caption = "Orders";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(messageBoxText, caption, button, icon);
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
