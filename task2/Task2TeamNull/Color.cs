using System.Xml.Serialization;

namespace Task2TeamNull
{
    public class Color
    {
        /// <summary>
        /// Gets/Sets an amount of red colour in RGB specification
        /// </summary>
        [XmlAttribute]
        public byte R { get; set; }

        /// <summary>
        /// Gets/Sets an amount of green colour in RGB specification
        /// </summary>
        [XmlAttribute]
        public byte G { get; set; }

        /// <summary>
        /// Gets/Sets an amount of blue colour in RGB specification
        /// </summary>
        [XmlAttribute]
        public byte B { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> class. 
        /// </summary>
        public Color() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> class
        /// Function to set colour of the border using RGB specification
        /// </summary>
        /// <param name="r">Amount of red</param>
        /// <param name="g">Amount of green</param>
        /// <param name="b">Amount of blue</param>
        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
