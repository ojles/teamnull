using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Meal> meals = new List<Meal>
            {
                Meal.Create("first name", 123),
                Meal.Create("second name", 1),
                Meal.Create("third name", 13),
            };

            menu.ItemsSource = meals;

            ICollectionView dataView = CollectionViewSource.GetDefaultView(menu.ItemsSource);
            dataView.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
        }
    }
}
