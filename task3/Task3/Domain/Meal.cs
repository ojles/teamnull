
using System.ComponentModel.DataAnnotations.Schema;

namespace Task3
{
    [Table("meal")]
    public class Meal
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("price")]
        public double Price { get; set; }
        [Column("image_path")]
        public string ImagePath { get; set; }
        [ForeignKey("meal_group_id")]
        public MealGroup Group { get; set; }

        public Meal()
        {
        }

        public static Meal Create(string name, double price)
        {
            return Create(name, price, null);
        }

        public static Meal Create(string name, double price, string imagePath)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("name", "Parameter cannot be null");
            }

            if (price < 0)
            {
                throw new System.ArgumentNullException("Meal price cannot be less then zero");
            }

            return new Meal
            {
                Name = name,
                Price = price,
                ImagePath = imagePath
            };
        }
    }
}
