using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Task3.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();

            Menu menu = (Menu)Application.Current.FindResource("SushiMenu");
            Menu.ItemsSource = menu.MealGroups;
        }

        private void PlusButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void MinusButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
