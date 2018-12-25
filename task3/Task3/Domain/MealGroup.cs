using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Task3
{
    [Table("meal_group")]
    public class MealGroup
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
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
