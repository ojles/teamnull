namespace teamnull
{
    public struct ColoredSide : IColor
    {
        public Color Color { get; }
        public double Length { get; }

        public ColoredSide(Color color, double length)
        {
            Color = color;
            Length = length;
        }
    }
}
