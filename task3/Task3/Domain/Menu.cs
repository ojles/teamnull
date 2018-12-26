using System.Collections.Generic;

namespace Task3.Domain
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
