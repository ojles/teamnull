
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

        public Meal(string name, double price)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("name", "Parameter cannot be null");
            }

            if (price < 0)
            {
                throw new System.ArgumentOutOfRangeException("Meal price cannot be less then zero");
            }

            Name = name;
            Price = price;
        }

        public Meal(string name, double price, string imagePath)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("name", "Parameter cannot be null");
            }

            if (price < 0)
            {
                throw new System.ArgumentOutOfRangeException("Meal price cannot be less then zero");
            }

            Name = name;
            Price = price;
            ImagePath = imagePath;
        }
    }
}
