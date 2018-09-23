namespace teamnull
{
    public enum Colors
    {
        Green,
        Red,
        Blue,
        Black,
        Yellow,
        Orange,
        Purple
    }
    
    public interface IColor
    {
        Colors Color { get; }
    }
}