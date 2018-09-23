using System;
using System.Collections.Generic;
using System.IO;

namespace teamnull
{
    public class ColoredTriangleComparer : IComparer<ColoredTriangle>
    {
        int IComparer<ColoredTriangle>.Compare(ColoredTriangle first, ColoredTriangle second)
        {
            return first.Perimeter().CompareTo(second.Perimeter());
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

        public ColoredTriangle(Color firstSideColor, double firstSideLength,
            Color secondSideColor, double secondSideLength,
            Color thirdSideColor, double thirdSideLength)
        {
            firstSide = new ColoredSide(firstSideColor, firstSideLength);
            secondSide = new ColoredSide(secondSideColor, secondSideLength);
            thirdSide = new ColoredSide(thirdSideColor, thirdSideLength);
        }

        public void Input(string line)
        {
            var textLine = line.Split(' ');
            firstSide = new ColoredSide((Color) Enum.Parse(typeof(Color), textLine[0]), double.Parse(textLine[1]));
            secondSide = new ColoredSide((Color) Enum.Parse(typeof(Color), textLine[2]), double.Parse(textLine[3]));
            thirdSide = new ColoredSide((Color) Enum.Parse(typeof(Color), textLine[4]), double.Parse(textLine[5]));
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

        public double Perimeter()
        {
            return firstSide.Length + secondSide.Length + thirdSide.Length;
        }

        public void ReadAndSort(string input_path, string output_path)
        {
            var sortedListOfTriangles = new SortedList<ColoredTriangle, double>(new ColoredTriangleComparer());
            var lines = File.ReadAllLines(input_path);
            foreach (var str in lines)
            {
                ColoredTriangle ct = new ColoredTriangle();
                ct.Input(str);
                sortedListOfTriangles.Add(ct, ct.Perimeter());
            }

            StreamWriter sw = new StreamWriter(output_path);
            for (int i = 0; i < sortedListOfTriangles.Count; i++)
            {
                foreach (ColoredTriangle ct in sortedListOfTriangles.Keys)
                {
                    sw.WriteLine(ct.ToString());
                }
            }
        }
    }
}