using System.Collections.Generic;

namespace Task3
{
    class Menu
    {
        private List<MealGroup> mealGroups;

        public List<MealGroup>MealGroups
        {
            get { return mealGroups; }
            set { mealGroups = value; }
        }

        Menu() { }

        Menu(List<MealGroup>mealGroups)
        {
            this.mealGroups = mealGroups;
        }
    }
}
