using System;
using System.Linq;

namespace Triangle
{
    internal static class Application
    {
        public static void Main(string[] args)
        {
            // run task2
            Console.WriteLine(" >>> task2");
            const string dataFolder = "../../Data";
            var triangles = Tasks.ReadTrianglesToSortedList($"{dataFolder}/Triangles.txt");
            Tasks.WriteTriangleListToFile(triangles, $"{dataFolder}/TrianglesSorted.txt");
            
            // run task3
            Console.WriteLine(" >>> task3");
            var triangleMap = Tasks.Task3(triangles.Select(pair => pair.Key).ToList());
            foreach (var mapPair in triangleMap)
            {
                Console.WriteLine($" > {mapPair.Key}");
                foreach (var triangle in mapPair.Value)
                {
                    Console.WriteLine($"   > {triangle}");
                }
            }

            // run task4
            Console.WriteLine(" >>> task4");
            var oneColorTriangles = Tasks.ColoringSide(triangles.Select(pair => pair.Key).ToList());
            foreach (var tr in oneColorTriangles)
            {
                Console.WriteLine(tr);
            }
            Console.ReadKey();
        }
    }
}
