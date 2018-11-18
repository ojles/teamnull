
namespace Task3
{
    class Meal
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }

        private Meal(string name, double price)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("Parameter cannot be null", "name");
            }

            if (price < 0)
            {
                throw new System.ArgumentOutOfRangeException("Price can not be less zero");
            }

            Name = name;
            Price = price;
        }

        private Meal(string name, double price, string imagePath)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("Parameter cannot be null", "name");
            }

            if (price < 0)
            {
                throw new System.ArgumentOutOfRangeException("Price can not be less zero");
            }

            Name = name;
            Price = price;
            ImagePath = imagePath;
        }
    }
}
