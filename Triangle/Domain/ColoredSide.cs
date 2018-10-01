using System;
using System.Collections.Generic;

namespace Triangle.Domain
{
    public struct ColoredSide : IColor
    {
        private const char FieldDelimiter = '-';

        public Color Color { get; private set; }
        public double Length { get; private set; }

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
