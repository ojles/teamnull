using System.Collections.Generic;
using System.IO;
using System.Linq;
using Triangle.Domain;

namespace Triangle
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

        public static SortedList<double, ColoredTriangle> ReadTrianglesToSortedList(string fileName)
        {
            var coloredTriangles = new SortedList<double, ColoredTriangle>();
            foreach (var triangleString in File.ReadAllLines(fileName))
            {
                var triangle = ColoredTriangle.Parse(triangleString);
                coloredTriangles.Add(triangle.Perimeter(), triangle);
            }

            return coloredTriangles;
        }

        public static void WriteTriangleListToFile(SortedList<double, ColoredTriangle> triangles, string outputFileName)
        {
            using (var writer = new StreamWriter(outputFileName))
            {
                foreach (var triangle in triangles)
                {
                    writer.WriteLine(triangle.Value);
                }
            }
        }
    }
}