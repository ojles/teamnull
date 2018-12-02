using System;
using System.Xml.Serialization;
using System.IO;
using Task2.Domain;

namespace Task2.Service
{
    /// <summary>
    /// Class to represent a serializer for an object of the Canvas
    /// </summary>
    public class CanvasService
    {
        /// <summary>
        /// Serializes an instance of the <see cref="Canvas"/>
        /// </summary>
        /// <param name="canvas">Object of the Canvas</param>
        /// <param name="fileName">Name of the file</param>
        public void Save(Canvas canvas, string fileName)
        {
            using (var stream = File.Create(fileName))
            {
                var serializer = new XmlSerializer(typeof(Canvas));
                serializer.Serialize(stream, canvas);
            }
        }

        /// <summary>
        /// Deserializes an instance of the <see cref="Canvas"/>
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        public Canvas Get(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Canvas));

            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    return (Canvas)serializer.Deserialize(reader);
                }
            }
            catch(InvalidOperationException e)
            {
                throw new ServiceException("Invalid file format.", e);
            }
        }
    }
}
