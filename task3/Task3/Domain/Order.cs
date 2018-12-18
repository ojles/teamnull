using System.Collections.Generic;
using System;

namespace Task3
{
    enum Status {
        None,
        Processing,
        Delivered,
        Cancelled,
        Failed
    };

    /// <summary>
    /// Class to represent an Order with order items
    /// </summary>
    public class Order
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
        private Status Status { get; set; } = Status.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/>
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        /// Calculates a price of the <see cref="Order"/>
        /// </summary>
        public double Price()
        {
            double price = 0;

            foreach (var item in OrderItems)
            {
                price += item.Price;
            }

            return price;
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
