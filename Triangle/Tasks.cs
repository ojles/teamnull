using System.Collections.Generic;
using System.IO;

namespace teamnull
{
    public static class Tasks
    {
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