using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task3.Domain
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
    [Table("order")]
    public class Order : INotifyPropertyChanged
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// List of the <see cref="OrderItem"/>
        /// </summary>
        [InverseProperty("Order")]
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        /// <summary>
        /// Name of the <see cref="Order"/>
        /// </summary>
        [Required]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Time when the <see cref="Order"/> is submitted
        /// </summary>
        [Required]
        [Column("submission_time")]
        public DateTime SubmissionTime { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        [Required]
        [Column("status", TypeName = "varchar(100)")]
        public Status Status { get; set; } = Status.None;

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

        public void Place()
        {
            SubmissionTime = DateTime.Now;
            Name = string.Format("order-{0}", SubmissionTime.Ticks);
        }


        public event PropertyChangedEventHandler PropertyChanged;

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
    }
}
