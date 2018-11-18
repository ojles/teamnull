
namespace Task3
{
    class Meal
    {
        public string Name
        {
          get { return Name; }
          set {
                if (value == null)
                {
                    throw new System.ArgumentNullException("name", "Parameter cannot be null");
                }

                Name = value;
            }
        }
        public double Price
        {
            get { return Price; }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentNullException("Meal price cannot be less then zero");
                }

                Price = value;
            }
        }
        public string ImagePath { get; set; }

        public Meal()
        {
        }

        public Meal(string name, double price)
        {     
            Name = name;
            Price = price;
        }

        public Meal(string name, double price, string imagePath)
        {        
            Name = name;
            Price = price;
            ImagePath = imagePath;
        }      

        public static Meal Create(string name, double price, string imagePath)
        {
            Meal meal = new Meal();
            meal.Name = name;
            meal.Price = price;
            meal.ImagePath = imagePath;
            return meal;
        }

        public static Meal Create(string name, double price)
        {
            return Create(name, price, null);
        }
    }
}
