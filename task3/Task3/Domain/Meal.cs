
namespace Task3
{
    class Meal
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }

        private Meal()
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
