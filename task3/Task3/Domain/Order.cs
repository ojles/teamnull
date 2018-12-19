using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Task3
{
    public enum Status {
        None,
        Processing,
        Delivered,
        Cancelled,
        Failed
    };

    /// <summary>
    /// Class to represent an Order with order items
    /// </summary>
    public class Order : INotifyPropertyChanged
    {
        /// <summary>
        /// List of the <see cref="OrderItem"/>
        /// </summary>
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        /// <summary>
        /// Name of the <see cref="Order"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Time when the <see cref="Order"/> is submitted
        /// </summary>
        public DateTime SubmissionTime { get; private set; }

        /// <summary>
        /// Order status
        /// </summary>
        public Status Status { get; set; } = Status.None;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/>
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        /// Calculates a price of the <see cref="Order"/>
        /// </summary>
        public double Price
        {
            get
            {
                double price = 0;
                foreach (var item in OrderItems)
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
        public override string ToString()
        {
            string result = "";
            result += string.Format("\n{0} \n {1} {2} \n\n", Name,SubmissionTime,Status);
            foreach(var i in OrderItems)
            {
                result += string.Format("{0} {1} {2} \n",i.Meal.Name, i.Amount, i.Price);
            }
            return result;
        }
        public static Order Place(List<OrderItem> orderItems, string name)
        {
            return new Order
            {
                OrderItems = orderItems,
                Name = name,
                Status = Status.Processing,
                SubmissionTime = DateTime.Now
            };
        }
    }
}
