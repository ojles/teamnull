using System;
using System.Collections.Generic;
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

            MealGroup group = MealGroup.Create("First Dish");
            group.AddMeal(Meal.Create("first name", 123));
            group.AddMeal(Meal.Create("second name", 23));
            group.AddMeal(Meal.Create("third name", 12));

            MealGroup group2 = MealGroup.Create("Second Dish");
            group2.AddMeal(Meal.Create("fourth name", 710));
            group2.AddMeal(Meal.Create("fifth name", 576));
            group2.AddMeal(Meal.Create("sixth name", 321));

            List<MealGroup> menu = new List<MealGroup>
            {
                group,
                group2
            };
            Menu.ItemsSource = menu;
        }
    }
}
