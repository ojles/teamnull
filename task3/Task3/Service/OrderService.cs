﻿using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
namespace Task3.Service
{
    /// <summary>
    /// Class to represent a serializer for an object of the <see cref="Order"/>
    /// </summary>
    public class OrderService
    {
        public OrderService()
        {
            if (!Directory.Exists(ServiceVariables.DataFolder))
            {
                Directory.CreateDirectory(ServiceVariables.DataFolder);
            }


            if (!Directory.Exists(ServiceVariables.OrdersFolderPath))
            {
                Directory.CreateDirectory(ServiceVariables.OrdersFolderPath);
            }
        }

        /// <summary>
        /// Serializes an instance of the <see cref="Order"/>
        /// </summary>
        /// <param name="order">Object to save</param>
        public void Save(Order order)
        {
            string orderFilePath = Path.Combine(ServiceVariables.OrdersFolderPath, order.Name);
            using (var stream = File.Create(orderFilePath))
            {
                var serializer = new XmlSerializer(typeof(Order));
                serializer.Serialize(stream, order);
            }
        }

        /// <summary>
        /// Load an instance of <see cref="Order"/> from file
        /// </summary>
        /// <param name="orderName">Name of the order</param>
        public Order Get(string orderName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Order));

            string orderFilePath = Path.Combine(ServiceVariables.OrdersFolderPath, orderName);
            using (var reader = new StreamReader(orderFilePath))
            {
                return (Order)serializer.Deserialize(reader);
         /// <summary>
         /// Loads all available orders
         /// </summary>
         /// <returns></returns>
        public List<Order> GetAll()
        {
            string[] orderFiles = Directory.GetFiles(ServiceVariables.OrdersFolderPath);
            List<Order> orders = new List<Order>();
            foreach (string orderFile in orderFiles)
            {
                orders.Add(Get(orderFile));
            }
            return orders;
        }
    }
}