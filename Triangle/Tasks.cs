using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace teamnull
{
    public static class Tasks
    {
        public static Dictionary<Color, List<ColoredTriangle>> Task3(List<ColoredTriangle> triangles)
        {
            return triangles
                .Where(triangle => triangle.FirstSide.Color.Equals(triangle.SecondSide.Color))
                .Where(triangle => triangle.FirstSide.Color.Equals(triangle.ThirdSide.Color))
                .GroupBy(triangle => triangle.FirstSide.Color)
                .ToDictionary(group => group.Key, group => group.ToList());
        }

        public static SortedList<ColoredTriangle, double> ReadTrianglesToSortedList(string fileName)
        {
            var trianglePerimeterComparer = Comparer<ColoredTriangle>.Create(
                (first, second) => first.Perimeter().CompareTo(second.Perimeter())
            );
            var coloredTriangles = new SortedList<ColoredTriangle, double>(trianglePerimeterComparer);
            foreach (var triangleString in File.ReadAllLines(fileName))
            {
                var triangle = ColoredTriangle.Parse(triangleString);
                coloredTriangles.Add(triangle, triangle.Perimeter());
            }
            return coloredTriangles;
        }

        public static void WriteTriangleListToFile(SortedList<ColoredTriangle, double> triangles, string outputFileName)
        {
            using (var writer = new StreamWriter(outputFileName))
            {
                foreach (var triangle in triangles)
                {
                    writer.WriteLine(triangle.Key);
                }
            }
        }
    }
}