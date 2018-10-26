using System.Xml.Serialization;

namespace Task2TeamNull
{
    public class Color
    {
        /// <summary>
        /// Gets/Sets Red color intensity in RGB specification
        /// </summary>
        [XmlAttribute]
        public byte R { get; set; }

        /// <summary>
        /// Gets/Sets Green color intensity in RGB specification
        /// </summary>
        [XmlAttribute]
        public byte G { get; set; }

        /// <summary>
        /// Gets/Sets Blue color intensity in RGB specification
        /// </summary>
        [XmlAttribute]
        public byte B { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/>
        /// </summary>
        public Color() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/>
        /// </summary>
        /// <param name="r">Intensity of red</param>
        /// <param name="g">Intensity of green</param>
        /// <param name="b">Intensity of blue</param>
        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
