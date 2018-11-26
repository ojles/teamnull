using System.Collections.Generic;

namespace Task3
{
    class MealGroup
    {
        public string Name { get; set; }
        public List<Meal> Meals { get; set; } = new List<Meal>();

        private MealGroup()
        {
        }

        public static MealGroup Create(string name, List<Meal> meals)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("name", "Parameter cannot be null");
            }

            return new MealGroup
            {
                Name = name,
                Meals = meals
            };
        }
    }
}
