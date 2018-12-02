using System.Collections.Generic;

namespace Task3
{
    public class Menu
    {
        public List<MealGroup> MealGroups { get; set; } = new List<MealGroup>();

        public Menu()
        {
        }

        public Menu(List<MealGroup> mealGroups)
        {
            MealGroups = mealGroups;
        }
    }
}
