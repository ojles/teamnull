﻿using System.Collections.Generic;

namespace Task3
{
    internal class Menu
    {
        public List<MealGroup> MealGroups { get; set; } = new List<MealGroup>();

        public Menu(List<MealGroup> mealGroups)
        {
            MealGroups = mealGroups;
        }
    }
}