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
        /// <summary>
        /// This function finds triangles in which two sides of the same color and repaint the third side
        /// </summary>
        /// <param name="triangles">list of triangles</param>
        /// <returns>list of triangles with repainted side</returns>
        public static List<ColoredTriangle> ColoringSide(List<ColoredTriangle> triangles)
        {
            var condition1 = triangles
                .Where(triangle => triangle.FirstSide.Color.Equals(triangle.SecondSide.Color))
                .Select(triangle => { triangle.ThirdSide = new ColoredSide(triangle.FirstSide.Color,triangle.ThirdSide.Length); return triangle; }).ToList();

            var condition2 = triangles
                .Where(triangle => triangle.FirstSide.Color.Equals(triangle.ThirdSide.Color))
                .Select(triangle => { triangle.SecondSide = new ColoredSide(triangle.FirstSide.Color, triangle.SecondSide.Length); return triangle; }).ToList();

            var condition3 = triangles
                .Where(triangle => triangle.SecondSide.Color.Equals(triangle.ThirdSide.Color))
                .Select(triangle => { triangle.FirstSide = new ColoredSide(triangle.SecondSide.Color, triangle.FirstSide.Length); return triangle; }).ToList();

            List<ColoredTriangle> result = condition2.Union(condition3).Union(condition1).ToList();
            
            return result;
        }
    }
}
