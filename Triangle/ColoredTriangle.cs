namespace teamnull
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
