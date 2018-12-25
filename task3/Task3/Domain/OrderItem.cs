using System.ComponentModel;

namespace Task3
{
    /// <summary>
    /// Class to represent an OrderItem
    /// </summary>
    public class OrderItem : INotifyPropertyChanged
    {
        private int amount;
       /// <summary>
       /// Parameterless constructor
       /// </summary>
       public OrderItem()
       {
       }

        /// <summary>
        /// Gets/Sets Meal
        /// </summary>
        public Meal Meal { get; set; }

        /// <summary>
        /// Gets/Sets Meal amount
        /// </summary>
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                OnChange("Amount");
                OnChange("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Calculates a price of the <see cref="OrderItem"/>
        /// </summary>
        public double Price
        {
            get
            {
                return Meal.Price * Amount;
            }
        }

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

        protected void OnChange(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
