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

            MealGroup group = MealGroup.Create("First Dish");
            group.AddMeal(Meal.Create("first name", 123));
            group.AddMeal(Meal.Create("second name", 23));
            group.AddMeal(Meal.Create("third name", 12));

            MealGroup group2 = MealGroup.Create("Second Dish");
            group2.AddMeal(Meal.Create("fourth name", 710));
            group2.AddMeal(Meal.Create("fifth name", 576));
            group2.AddMeal(Meal.Create("sixth name", 321));

            menu.ItemsSource = group.Meals;

            ICollectionView dataView = CollectionViewSource.GetDefaultView(menu.ItemsSource);
            dataView.GroupDescriptions.Add(new PropertyGroupDescription("Group.Name"));
        }
    }
}
