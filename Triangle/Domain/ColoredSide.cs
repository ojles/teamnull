using System;

namespace Triangle.Domain
{
    /// <summary>
    /// Structure class that is used to store a colored side
    /// </summary>
    public struct ColoredSide : IColor
    {
        private const char FieldDelimiter = '-';

        /// <summary>
        /// Color property
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Side length
        /// </summary>
        public double Length { get; private set; }
        
        public ColoredSide(Color color, double length)
        {
            Color = color;
            Length = length;
        }

        public override string ToString()
        {
            return $"{Color}{FieldDelimiter}{Length}";
        }

        public bool Equals(ColoredSide other)
        {
            return Color == other.Color && Length.Equals(other.Length);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ColoredSide && Equals((ColoredSide) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Color * 397) ^ Length.GetHashCode();
            }
        }

        /// <summary>
        /// This method is creating a side from a string in a specific format
        /// </summary>
        /// <param name="side">The actual string</param>
        /// <returns>New instance of ColoredSide</returns>
        /// <exception cref="DomainException">Is thrown usually when the color value is invalid</exception>
        public static ColoredSide Parse(string side)
        {
            var fields = side.Split(FieldDelimiter);
            try
            {
                return new ColoredSide
                {
                    Color = (Color) Enum.Parse(typeof(Color), fields[0]),
                    Length = double.Parse(fields[1])
                };
            }
            catch (ArgumentException e)
            {
                throw new DomainException($"Failed to parse ColoredSide from  string \"{side}\"", e);
            }
        }
    }
}
