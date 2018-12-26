using System.IO;
using System.Xml.Serialization;
using Task3.Domain;

namespace Task3.Service
{
    /// <summary>
    /// Class to represent a serializer for an object of the <see cref="Menu"/>
    /// </summary>
    public class MenuService
    {
        /// <summary>
        /// Deserializes an instance of type <see cref="Menu"/>
        /// </summary>
        public Menu Get()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Menu));

            using (var reader = new StreamReader(ServiceVariables.MenuFilePath))
            {
                return (Menu)serializer.Deserialize(reader);
            }
        }
    }
}
