
namespace Task3
{
    class Meal
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }

        Meal(string name, double price)
        {
            Name = name;
            Price = price;
        }

        Meal(string name, double price, string imagePath)
        {
            Name = name;
            Price = price;
            ImagePath = imagePath;
        }
    }
}
