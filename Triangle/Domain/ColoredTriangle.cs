namespace Triangle.Domain
{
    public class ColoredTriangle
    {
        private const char FieldDelimiter = ':';

        public ColoredSide FirstSide { get; private set; }
        public ColoredSide SecondSide { get; private set; }
        public ColoredSide ThirdSide { get; private set; }

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

        public static ColoredTriangle Parse(string triangle)
        {
            var fields = triangle.Split(FieldDelimiter);
            return new ColoredTriangle
            {
                FirstSide = ColoredSide.Parse(fields[0]),
                SecondSide = ColoredSide.Parse(fields[1]),
                ThirdSide = ColoredSide.Parse(fields[2])
            };
        }
    }
}
