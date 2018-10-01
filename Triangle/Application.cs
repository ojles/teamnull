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
            Tasks.WriteTriangleListToFile(triangles, "TrianglesSorted.txt");
            
            // run task3
            Console.WriteLine(" >>> task3");
            var triangleMap = Tasks.Task3(triangles.Select(pair => pair.Value).ToList());
            foreach (var mapPair in triangleMap)
            {
                Console.WriteLine($" > {mapPair.Key}");
                foreach (var triangle in mapPair.Value)
                {
                    Console.WriteLine($"   > {triangle}");
                }
            }
        }
    }
}
