namespace ColoredFigure
{
    using System;
    using System.IO;
    using System.Collections.Generic;

    public class CTriangle
    {
        public enum Colors
        {
            green,
            red,
            blue,
            black,
            yellow,
            orange,
            purple
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

       public static void Main(string[] args)
        {
            //var strs = File.ReadAllLines("input.txt");
            //List<ColoredTriangle> ctList = new List<ColoredTriangle>();
            //foreach (var item in strs)
            //{
            //    ColoredTriangle ct = new ColoredTriangle();
            //    ct.Input(item);
            //    ctList.Add(ct);
            //    ct.Print("output.txt");
            //}
        }
    }
}
