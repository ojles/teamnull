namespace ColoredFigure
{
    using System;
    using System.Collections.Generic;
    using System.IO;

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

    public struct ColoredSide : IColor
    {
        private Colors color;
        private double length;

        public ColoredSide(Colors color, double length)
        {
            this.color = color;
            this.length = length;
        }

        public Colors Color
        {
            get { return this.color; }
        }

        public double Length
        {
            get
            {
                return this.length;
            }
        }
    }

    public class ColoredTriangle
    {
        private ColoredSide firstSide;
        private ColoredSide secondSide;
        private ColoredSide thirdSide;

        public ColoredTriangle()
        {
        }

        public ColoredTriangle(Colors firstSideColor, double firstSideLength, Colors secondSideColor, double secondSideLength, Colors thirdSideColor, double thirdSideLength)
        {
            this.firstSide = new ColoredSide(firstSideColor, firstSideLength);
            this.secondSide = new ColoredSide(secondSideColor, secondSideLength);
            this.thirdSide = new ColoredSide(thirdSideColor, thirdSideLength);
        }

        public void Input(string line)
        {
            var textLine = line.Split(' ');
            this.firstSide = new ColoredSide((Colors)Enum.Parse(typeof(Colors), textLine[0]), double.Parse(textLine[1]));
            this.secondSide = new ColoredSide((Colors)Enum.Parse(typeof(Colors), textLine[2]), double.Parse(textLine[3]));
            this.thirdSide = new ColoredSide((Colors)Enum.Parse(typeof(Colors), textLine[4]), double.Parse(textLine[5]));
        }

        public override string ToString()
        {
            return $"First side color: {firstSide.Color}, with length: {firstSide.Length}," +
                $" Second side color: {secondSide.Color}, with length: {secondSide.Length}," +
                $" Third side color: {thirdSide.Color}, with length: {thirdSide.Length}.";
        }

        public void Print(string path)
        {
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(this.ToString());
            sw.Close();
        }
    }
}