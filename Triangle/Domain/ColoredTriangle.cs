namespace Triangle.Domain
{
    /// <summary>
    /// Structure class to store a triangle
    /// </summary>
    public class ColoredTriangle
    {
        private const char FieldDelimiter = ':';

        public ColoredSide FirstSide { get; private set; }
        public ColoredSide SecondSide { get; private set; }
        public ColoredSide ThirdSide { get; private set; }

        /// <summary>
        /// Calculates the perimeter of this triangle
        /// </summary>
        /// <returns>The perimeter</returns>
        public double Perimeter()
        {
            return FirstSide.Length + SecondSide.Length + ThirdSide.Length;
        }

        public override string ToString()
        {
            return $"{FirstSide}{FieldDelimiter}{SecondSide}{FieldDelimiter}{ThirdSide}";
        }

        protected bool Equals(ColoredTriangle other)
        {
            return FirstSide.Equals(other.FirstSide)
                   && SecondSide.Equals(other.SecondSide)
                   && ThirdSide.Equals(other.ThirdSide);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ColoredTriangle) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = FirstSide.GetHashCode();
                hashCode = (hashCode * 397) ^ SecondSide.GetHashCode();
                hashCode = (hashCode * 397) ^ ThirdSide.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// This method is creating a triangle from a string specified in a specific format
        /// </summary>
        /// <param name="triangle">Actual string</param>
        /// <returns>New instance of ColoredTriangle</returns>
        /// <exception cref="DomainException">
        /// Is thrown when triangle string has an invalid format or the length of sides are invalid
        /// </exception>
        public static ColoredTriangle Parse(string triangle)
        {
            var fields = triangle.Split(FieldDelimiter);
            if (fields.Length < 3)
            {
                throw new DomainException($"Not enough sides for triangle ({fields.Length})");
            }
            return Create(
                ColoredSide.Parse(fields[0]),
                ColoredSide.Parse(fields[1]),
                ColoredSide.Parse(fields[2])
            );
        }

        /// <summary>
        /// This method is constructing a triangle from three sides
        /// </summary>
        /// <param name="a">First side</param>
        /// <param name="b">Second side</param>
        /// <param name="c">Third side</param>
        /// <returns>New instance of ColoredTriangle</returns>
        /// <exception cref="DomainException">Is thrown when invalid length of sides are specified</exception>
        public static ColoredTriangle Create(ColoredSide a, ColoredSide b, ColoredSide c)
        {
            if (a.Length + b.Length <= c.Length || a.Length + c.Length <= b.Length || b.Length + c.Length <= a.Length)
            {
                throw new DomainException($"Invalid side length for triangle ({a.Length}, {b.Length}, {c.Length})");
            }

            return new ColoredTriangle
            {
                FirstSide = a,
                SecondSide = b,
                ThirdSide = c
            };
        }
    }
}