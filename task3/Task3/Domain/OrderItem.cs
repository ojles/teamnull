using System.ComponentModel;

namespace Task3
{
    /// <summary>
    /// Class to represent an OrderItem
    /// </summary>
    [Table("order_item")]
    public class OrderItem : INotifyPropertyChanged
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets/Sets Meal
        /// </summary>
        [Required]
        [ForeignKey("meal_id")]
        public Meal Meal { get; set; }

        private int amount;

        /// <summary>
        /// Gets/Sets Meal amount
        /// </summary>
        [Required]
        [Column("amount")]
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

        /// <summary>
        /// Gets/Sets Order to which this item belongs
        /// </summary>
        [ForeighKey("order_id")]
        public Order Order { get; set; }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public OrderItem()
        {
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

        protected void OnChange(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
