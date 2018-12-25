using System.Collections.Generic;

namespace Task3
{
    public class MealGroup
    {
        public string Name { get; set; }
        public List<Meal> Meals { get; set; } = new List<Meal>();

        public MealGroup()
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

        public override bool Equals(object obj)
        {
            if (!(obj is MealGroup other))
            {
                return false;
            }

            return Equals(other);
        }

        public bool Equals(MealGroup other)
        {
            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
