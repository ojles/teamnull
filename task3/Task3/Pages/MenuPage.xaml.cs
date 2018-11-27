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

            MealGroup mg1 = (MealGroup)Application.Current.FindResource("mg1");

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
                group2,
                mg1
            };
            Menu.ItemsSource = menu;
        }
    }
}
