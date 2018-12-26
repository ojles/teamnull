﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Task3.Service;
using Task3.Domain;
using Task3.DataAccess;

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
        private Domain.Menu menu;
        private UnitOfWork unitOfWork = new UnitOfWork();

        public MenuPage()
        {
            InitializeComponent();

            List<OrderItem> items = new List<OrderItem>();
            foreach (Meal meal in unitOfWork.GetMeals())
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
            order.Place();
            orderService.Save(order);
        }
    }
}
