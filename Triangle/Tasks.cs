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

        /// <summary>
        /// This function reads ColoredTriangle objects and puts them into a sorted list.
        /// The key of the sorted list is the perimeter of the corresponding triangle
        /// </summary>
        /// <param name="fileName">The name of the file</param>
        /// <returns>Returns the sorted list of objects of ColoredTriangle class</returns>
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

        /// <summary>
        /// This function writes all objects from list of ColoredTriangle class into file
        /// </summary>
        /// <param name="triangles">A list of ColoredTriangle objects</param>
        /// <param name="outputFileName">The name of the output file</param>
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

        /// <summary>
        /// This function finds triangles in which two sides of the same color and repaint the third side
        /// </summary>
        /// <param name="triangles">list of triangles</param>
        /// <returns>list of triangles with repainted side</returns>
        public static List<ColoredTriangle> ColoringSide(List<ColoredTriangle> triangles)
        {
            List<ColoredTriangle> result = new List<ColoredTriangle>();

            foreach (var item in triangles)
            {
                if (item.FirstSide.Color.Equals(item.SecondSide.Color) &&
                    item.FirstSide.Color.Equals(item.ThirdSide.Color))
                {
                    continue;
                }

                if (item.FirstSide.Color.Equals(item.SecondSide.Color))
                {
                    item.ThirdSide = new ColoredSide(item.FirstSide.Color, item.ThirdSide.Length);
                    result.Add(item);
                }
                else if (item.FirstSide.Color.Equals(item.ThirdSide.Color))
                {
                    item.SecondSide = new ColoredSide(item.FirstSide.Color, item.SecondSide.Length);
                    result.Add(item);
                }
                else if (item.SecondSide.Color.Equals(item.ThirdSide.Color))
                {
                    item.FirstSide = new ColoredSide(item.SecondSide.Color, item.FirstSide.Length);
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
