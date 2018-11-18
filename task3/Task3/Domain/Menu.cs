using System.Collections.Generic;

namespace Task3
{
    class Menu
    {
        public List<MealGroup> MealGroups { get; set; } = new List<MealGroup>();

        private Menu(List<MealGroup> mealGroups)
        {
            MealGroups = mealGroups;
        }
    }
}
