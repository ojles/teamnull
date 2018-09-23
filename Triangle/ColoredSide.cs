namespace teamnull
{
    public struct ColoredSide : IColor
    {
        public Colors Color { get; }
        public double Length { get; }

        public ColoredSide(Colors color, double length)
        {
            Color = color;
            Length = length;
        }
    }
}
