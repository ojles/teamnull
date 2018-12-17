using System.Collections.Generic;
using System.ComponentModel;

namespace Task3
{
    /// <summary>
    /// Class to represent an Order with order items
    /// </summary>
    public class Order : INotifyPropertyChanged
    {
        /// <summary>
        /// List of the <see cref="OrderItem"/>
        /// </summary>
        public List<OrderItem> ListOfOrders { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/>
        /// </summary>
        public Order()
        {
            ListOfOrders = new List<OrderItem>();
        }

        /// <summary>
        /// Calculates a price of the <see cref="Order"/>
        /// </summary>
        public double Price
        {
            get
            {
                double price = 0;
                foreach (var item in ListOfOrders)
                {
                    price += item.Price;
                }
                return price;
            }
        }

        public void OrderItemsChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
