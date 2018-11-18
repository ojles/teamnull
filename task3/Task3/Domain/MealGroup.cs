using System.Collections.Generic;

namespace Task3
{
    class MealGroup
    {
        public string Name { get; set; }
        public List<Meal> Meals { get; set; } = new List<Meal>();

        private MealGroup(string name, List<Meal> meals)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("Parameter cannot be null", "name");
            }

            Name = name;           
            Meals = meals;           
        }
    }
}
