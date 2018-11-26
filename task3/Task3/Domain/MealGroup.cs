using System.Collections.Generic;

namespace Task3
{
    class MealGroup
    {
        public string Name { get; private set; }
        public List<Meal> Meals { get; set; } = new List<Meal>();

        private MealGroup()
        {
        }

        public MealGroup AddMeal(Meal meal)
        {
            Meals.Add(meal);
            meal.Group = this;
            return this;
        }

        public static MealGroup Create(string name)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("name", "Parameter cannot be null");
            }

            return new MealGroup
            {
                Name = name
            };
        }
    }
}
