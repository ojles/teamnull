using System.Collections.Generic;
using System;

namespace Task3
{
    enum Status { Failed, InProgress, Delivered, Cancelled, Success, None};
    /// <summary>
    /// Class to represent an Order with order items
    /// </summary>
    public class Order
    {
        /// <summary>
        /// List of the <see cref="OrderItem"/>
        /// </summary>
        public List<OrderItem> ListOfOrderItems { get; set; }

        /// <summary>
        /// Name of the <see cref="Order"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Time when the <see cref="Order"/> is submitted
        /// </summary>
        public DateTime Submission_time { get; private set; }

        private Status status;
        public string OrderStatus
        { get
            {
                switch (status)
                {
                    case Status.InProgress: return "In Progress";
                    default: return status.ToString();
                }
                
            }
            private set
            {
                switch(value)
                {
                    case "In Progress": status = Status.InProgress; break;
                    case "Delivered": status = Status.Delivered; break;
                    case "Failed": status = Status.Failed; break;
                    case "Cancelled": status = Status.Cancelled; break;
                    case "Success": status = Status.Success; break;
                    case "None": status = Status.None; break;
                    default: throw new FormatException("Invalid status!\n");
                }
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/>
        /// </summary>
        public Order()
        {
            ListOfOrderItems = new List<OrderItem>();
            Name = "Order";
            Submission_time = new DateTime(2018,1,1,12,2,12);
            OrderStatus = "None";
        }

        public Order(List<OrderItem> list, string name, 
            DateTime submission_time, string order_status)
        {
            ListOfOrderItems = list;
            Name = name;
            Submission_time = submission_time;
            OrderStatus = order_status;
        }

        /// <summary>
        /// Calculates a price of the <see cref="Order"/>
        /// </summary>
        public double Price()
        {
            double price = 0;

            foreach (var item in ListOfOrderItems)
            {
                price += item.Price;
            }

            return price;
        }
    }
}
