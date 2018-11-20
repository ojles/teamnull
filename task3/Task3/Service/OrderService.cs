using System.Xml.Serialization;
using System.IO;

namespace Task3
{
    /// <summary>
    /// Class to represent a serializer for an object of the <see cref="Order"/>
    /// </summary>
    class OrderService
    {
        /// <summary>
        /// Serializes an instance of the <see cref="Order"/>
        /// </summary>
        /// <param name="order">Object of the Order</param>
        /// <param name="fileName">Name of the file</param>
        public void Save(Order order, string fileName)
        {
            using (var stream = File.Create(fileName))
            {
                var serializer = new XmlSerializer(typeof(Order));
                serializer.Serialize(stream, order);
            }
        }

        /// <summary>
        /// Deserializes an instance of the <see cref="Order"/>
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        public Order Get(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Order));

            using (var reader = new StreamReader(fileName))
            {
                return (Order)serializer.Deserialize(reader);
            }
        }
    }
}
