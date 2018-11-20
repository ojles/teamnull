using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Class to represent an OrderItem
    /// </summary>
    class OrderItem
    {
        /// <summary>
        /// Gets/Sets Meal
        /// </summary>
        public Meal Meal { get; set; }

        /// <summary>
        /// Gets/Sets Meal amount
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItem"/>
        /// </summary>
        /// <param name="someMeal">Meal</param>
        /// <param name="amount">Meal's amount</param>
        public OrderItem(Meal someMeal, int amount)
        {
            Meal = someMeal;
            Amount = amount;
        }

        /// <summary>
        /// Calculates a price of the <see cref="OrderItem"/>
        /// </summary>
        public double Price()
        {
            return Meal.Price * Amount;
        }
    }
}
