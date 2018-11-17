using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

    class MealGroup
    {
        private string name;
        private List<Meal> meals;
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Meal> Meals
        {
            get { return meals; }
            set { meals = value; }
        }

        MealGroup() { }

        MealGroup(string name, List<Meal>meals)
        {
            this.name = name;
            this.meals = meals;
        }
    }

    class Menu
    {
        private List<MealGroup> mealGroups;

        public List<MealGroup>MealGroups
        {
            get { return mealGroups; }
            set { mealGroups = value; }
        }

        Menu() { }

        Menu(List<MealGroup>mealGroups)
        {
            this.mealGroups = mealGroups;
        }
    }
}
