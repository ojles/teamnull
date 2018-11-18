﻿
namespace Task3
{
    class Meal
    {
        private string name;
        private double price;
        private string pathToImage;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public string PathToImage
        {
            get { return pathToImage; }
            set { pathToImage = value; }
        }

        Meal() { }

        Meal(string name, double price, string pathToImage)
        {
            this.name = name;
            this.price = price;
            this.pathToImage = pathToImage;
        }
    }
}
