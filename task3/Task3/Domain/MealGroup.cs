using System.Collections.Generic;

namespace Task3
{
    class MealGroup
    {
        private string name;
        private List<Meal> meals;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Meal> Meals
        {
            get { return meals; }
            set { meals = value; }
        }

        MealGroup() { }

        MealGroup(string name, List<Meal> meals)
        {
            this.name = name;
            this.meals = meals;
        }
    }
}
