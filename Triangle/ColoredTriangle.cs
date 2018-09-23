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

        public void ReadAndSort(string input_path, string output_path)
        {
            var sortedListOfTriangles = new SortedList<ColoredTriangle, double>(new ColoredTriangleComparer());
            var lines = File.ReadAllLines(input_path);
            foreach (var str in lines)
            {
                ColoredTriangle ct = ColoredTriangle.Parse(str);
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