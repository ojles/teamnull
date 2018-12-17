using System.Collections.Generic;

namespace Task3
{
    public class Menu
    {
        public List<Meal> Meals { get; set; } = new List<Meal>();

        public Menu()
        {
        }

        public Menu(List<Meal> meals)
        {
            Meals = meals;
        }
    }
}
