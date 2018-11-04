using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Pentagon.Domain
{
    /// <summary>
    /// Class to represent a serializer for an object of the Canvas
    /// </summary>
    public static class CanvasSerializer
    {
        /// <summary>
        /// Serializes an instance of the <see cref="Canvas"/>
        /// </summary>
        /// <param name="canvas">Object of the Canvas</param>
        /// <param name="fileName">Name of the file</param>
        public static void SerilizeCanvas(Canvas canvas, string fileName)
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
        public static Canvas DeserializePentagon(string fileName)
        {
            Canvas deserializedCanvas = new Canvas();
            XmlSerializer serializer = new XmlSerializer(typeof(Canvas));

            using (var reader = new StreamReader(fileName))
            {
                deserializedCanvas = (Canvas)serializer.Deserialize(reader);
            }

            return deserializedCanvas;
        }
    }
}
