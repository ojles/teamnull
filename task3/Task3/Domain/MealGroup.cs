using System.Collections.Generic;

namespace Task3
{
    class MealGroup
    {
        public string Name
        {
            get { return Name; }
            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("name", "Parameter cannot be null");
                }

                Name = value;
            }
        }

        public List<Meal> Meals { get; set; } = new List<Meal>();

        public MealGroup(string name, List<Meal> meals)
        {
            Name = name;
            Meals = meals;
        }
    }
}
