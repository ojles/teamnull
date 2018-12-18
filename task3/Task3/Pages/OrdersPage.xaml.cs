using System.Collections.Generic;
using System.Windows.Controls;
using System;
using Task3.Service;
namespace Task3.Pages
{
    /// <summary>
    /// Interaction logic for RecepitPage.xaml
    /// </summary>
    public partial class ReceiptPage : Page
    {
        private OrderService orderService = new OrderService();
        public ReceiptPage()
        {
            InitializeComponent();

            Orders.ItemsSource = orderService.GetAll();

        }
    }
}