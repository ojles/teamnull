using System.Collections.Generic;

namespace Task3
{
    class MealGroup
    {
        public string Name { get; set; }
        public List<Meal> Meals { get; set; } = new List<Meal>();

        MealGroup(string name, List<Meal> meals)
        {
            Name = name;
            Meals = meals;
        }
    }
}
