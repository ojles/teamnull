using System;

namespace teamnull
{
    public struct ColoredSide : IColor
    {
        private const char FieldDelimiter = '-';

        public Color Color { get; private set; }
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

        public static ColoredSide Parse(string side)
        {
            var fields = side.Split(FieldDelimiter);
            return new ColoredSide
            {
                Color = (Color) Enum.Parse(typeof(Color), fields[0]),
                Length = double.Parse(fields[1])
            };
        }
    }
}
