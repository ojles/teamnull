namespace Triangle.Domain
{
    public enum Color
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
        Color Color { get; }
    }
}
